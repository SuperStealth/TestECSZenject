using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestEcsZenject
{
    public class DestroySystem : IEcsDestroySystem
    {
        private EcsFilter<TransformComponent> _filter;
        public void Destroy()
        {
            foreach (var i in _filter)
            {
                ref var transformComponent = ref _filter.Get1(i);
                Object.Destroy(transformComponent.Transform.gameObject);
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}

