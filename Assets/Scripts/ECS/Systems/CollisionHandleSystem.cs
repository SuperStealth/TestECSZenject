using Leopotam.Ecs;
using UnityEngine;
namespace TestEcsZenject
{
    public class CollisionHandleSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionEnterEvent, TransformComponent, HealthComponent, DamageComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                
                ref var collision = ref _filter.Get1(i);
                if (collision.collider.tag == "Player")
                {
                    ref var damageComponent = ref _filter.Get4(i);

                    var colliderEntity = collision.collider.GetComponent<EntityReference>().entity;

                    ref var colliderHealthComponent = ref colliderEntity.Get<HealthComponent>();

                    colliderHealthComponent.Health -= damageComponent.Damage;
                    if (colliderHealthComponent.Health <= 0f)
                    {
                        colliderEntity.Get<DestroyTagComponent>();
                    }

                    ref var transformComponent = ref _filter.Get2(i);
                    Object.Destroy(transformComponent.Transform.gameObject);
                    _filter.GetEntity(i).Destroy();
                }
                else if (collision.collider.tag == "Bullet")
                {
                    var colliderEntity = collision.collider.GetComponent<EntityReference>().entity;
                    ref var healthComponent = ref _filter.Get3(i);
                    healthComponent.Health -= colliderEntity.Get<DamageComponent>().Damage;
                    ref var transformComponent = ref colliderEntity.Get<TransformComponent>();
                    colliderEntity.Get<DestroyTagComponent>();
                    _filter.GetEntity(i).Del<CollisionEnterEvent>();
                }
                
            }
        }
    }
}

