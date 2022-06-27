using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class CollisionHandleSystem : IEcsRunSystem
    {
        private GameUI _gameUI;
        
        private EcsFilter<CollisionEnterEvent, TransformComponent, HealthComponent, DamageComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {               
                ref var collision = ref _filter.Get1(i);

                var colliderEntity = collision.collider.GetComponent<EntityReference>().entity;
                if (colliderEntity.Has<PlayerTagComponent>())
                {
                    ref var damageComponent = ref _filter.Get4(i);

                    ref var colliderHealthComponent = ref colliderEntity.Get<HealthComponent>();

                    colliderHealthComponent.Health -= damageComponent.Damage;
                    _gameUI.SetHealth(colliderHealthComponent.Health);
                    if (colliderHealthComponent.Health <= 0f)
                    {
                        colliderEntity.Get<DestroyTagComponent>();
                    }

                    ref var transformComponent = ref _filter.Get2(i);
                    Object.Destroy(transformComponent.Transform.gameObject);
                    _filter.GetEntity(i).Destroy();
                }
                else if (colliderEntity.Has<BulletTagComponent>())
                {
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

