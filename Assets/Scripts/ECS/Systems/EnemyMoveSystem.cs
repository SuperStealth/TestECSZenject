using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestEcsZenject
{
    public class EnemyMoveSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyTagComponent, TransformComponent, MovableComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformComponent = ref _filter.Get2(i);
                ref var speedComponent = ref _filter.Get3(i);

                var speed = speedComponent.Speed;
                Vector3 positionDelta = new Vector3(- speed * Time.deltaTime, 0f, 0f);
                transformComponent.Transform.position += positionDelta;
            }
        }
    }
}

