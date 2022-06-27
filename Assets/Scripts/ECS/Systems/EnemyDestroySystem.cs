using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class EnemyDestroySystem : IEcsRunSystem
    {        
        private const float LeftBound = -12f;
        
        private EcsWorld _world;
        private EcsFilter<EnemyTagComponent, TransformComponent, HealthComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transform = ref _filter.Get2(i);
                ref var health = ref _filter.Get3(i);
                if (transform.Transform.position.x < LeftBound || health.Health <= 0f)
                {                  
                    _filter.GetEntity(i).Get<DestroyTagComponent>();

                    if (health.Health <= 0f)
                    {
                        _world.NewEntity().Get<IncreaseScoreEvent>();
                    }                  
                }               
            }
        }
    }
}
