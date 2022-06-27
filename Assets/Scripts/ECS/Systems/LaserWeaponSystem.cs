using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class LaserWeaponSystem : IEcsRunSystem
    {
        private const float laserLength = 24f;
        
        private EcsFilter<LaserWeaponComponent, TransformComponent, InputComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var input = ref _filter.Get3(i);
                if (input.IsShooting)
                {
                    ref var laser = ref _filter.Get1(i);
                    ref var transform = ref _filter.Get2(i);
                    RaycastHit2D hit = Physics2D.Raycast(transform.Transform.position, Vector2.right);
                    if (hit.collider != null)
                    {
                        Debug.Log(hit.collider.gameObject.name);
                    }
                    else
                    {

                    }
                }
            }          
        }
    }
}