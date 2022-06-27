using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<MovableComponent, InputComponent, TransformComponent> movableFilter = null;

        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var movableComponent = ref movableFilter.Get1(i);
                ref var inputComponent = ref movableFilter.Get2(i);
                ref var transformComponent = ref movableFilter.Get3(i);

                ref var direction = ref inputComponent.InputDirection;
                var currentPosition = transformComponent.Transform.position;
                var speed = movableComponent.Speed;

                var positionDelta = new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime);
                transformComponent.Transform.position = currentPosition + positionDelta;
            }
        }
    }
}

