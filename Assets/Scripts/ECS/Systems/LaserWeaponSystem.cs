using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class LaserWeaponSystem : IEcsRunSystem
    {
        private const float laserLength = 24f;

        private GameBinds _binds;
        private EcsFilter<LaserWeaponComponent, TransformComponent, InputComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var laser = ref _filter.Get1(i);
                ref var input = ref _filter.Get3(i);
                if (input.IsShooting)
                {                  
                    ref var transform = ref _filter.Get2(i);

                    laser.LaserObject.SetActive(true);

                    RaycastHit2D hit = Physics2D.Raycast(transform.Transform.position + Vector3.right, Vector2.right);

                    var scale = laser.LaserObject.transform.localScale;
                    if (hit.collider != null)
                    {
                        laser.LaserObject.transform.position = transform.Transform.position + new Vector3(hit.distance * 0.5f + 1f, 0f, 0f);
                        laser.LaserObject.transform.localScale = new Vector3(hit.distance + 1f, scale.y, scale.z);

                        if (hit.collider.gameObject.TryGetComponent<AsteroidCollisionHandler>(out var enemyComponent))
                        {
                            var enemyEntity = enemyComponent.Entity;
                            if (enemyEntity.Has<EnemyTagComponent>())
                            {
                                enemyEntity.Get<ReceivedDamageEvent>().Damage = laser.DPS * Time.deltaTime;
                            }
                        };
                    }
                    else
                    {
                        laser.LaserObject.transform.localScale = new Vector3(laserLength, scale.y, scale.z);
                        laser.LaserObject.transform.position = transform.Transform.position + new Vector3(laserLength * 0.5f + 0.5f, 0f, 0f);          
                    }
                }
                else
                {
                    laser.LaserObject.SetActive(false);
                }
            }          
        }
    }
}