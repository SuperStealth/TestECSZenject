using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class EntityDestroySystem : IEcsRunSystem
    {
        private EcsFilter<DestroyTagComponent, TransformComponent>.Exclude<PlayerTagComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformComponent = ref _filter.Get2(i);
                Object.Destroy(transformComponent.Transform.gameObject);
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}

