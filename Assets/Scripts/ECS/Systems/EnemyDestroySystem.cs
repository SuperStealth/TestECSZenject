using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public class EnemyDestroySystem : IEcsRunSystem
    {
        private const float LeftBound = -12f;
        
        private EcsFilter<EnemyTagComponent, TransformComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transform = ref _filter.Get2(i);
                if (transform.CharacterTransform.position.x < LeftBound)
                {
                    Object.Destroy(transform.CharacterTransform.gameObject);
                    _filter.GetEntity(i).Destroy();
                }
            }
        }
    }
}
