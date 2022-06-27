using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class DestroySystem : IEcsDestroySystem
    {
        private EcsFilter<TransformComponent> _filter;

        public void Destroy()
        {
            foreach (var i in _filter)
            {
                ref var transformComponent = ref _filter.Get1(i);
                if (transformComponent.Transform != null)
                {
                    Object.Destroy(transformComponent.Transform.gameObject);
                }               
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}