using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestEcsZenject
{
    public class BulletDespawnSystem : IEcsRunSystem
    {
        private const float RightDespawnBound = 12f;
        
        private EcsFilter<BulletTagComponent, TransformComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transform = ref _filter.Get2(i);
                if (transform.Transform.position.x > RightDespawnBound)
                {
                    Object.Destroy(transform.Transform.gameObject);
                    _filter.GetEntity(i).Destroy();
                }
            }
        }
    }
}