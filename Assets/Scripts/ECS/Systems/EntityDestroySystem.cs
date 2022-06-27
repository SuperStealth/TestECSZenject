using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestEcsZenject
{
    public class EntityDestroySystem : IEcsRunSystem
    {
        private EcsFilter<DestroyTagComponent, TransformComponent> _filter;
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

