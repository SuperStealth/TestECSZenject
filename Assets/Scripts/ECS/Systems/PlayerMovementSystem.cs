using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private const float minX = -10f;
        private const float maxX = 10f;
        private const float minY = -4f;
        private const float maxY = 4f;

        private readonly EcsFilter<MovableComponent, InputComponent, TransformComponent> _movableFilter = null;

        public void Run()
        {
            foreach (var i in _movableFilter)
            {
                ref var movableComponent = ref _movableFilter.Get1(i);
                ref var inputComponent = ref _movableFilter.Get2(i);
                ref var transformComponent = ref _movableFilter.Get3(i);

                ref var direction = ref inputComponent.InputDirection;
                var currentPosition = transformComponent.Transform.position;
                var speed = movableComponent.Speed;

                var positionDelta = new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime);
                var newPosition = currentPosition + positionDelta;

                if (newPosition.x < minX) newPosition.x = minX;
                if (newPosition.x > maxX) newPosition.x = maxX;
                if (newPosition.y < minY) newPosition.y = minY;
                if (newPosition.y > maxY) newPosition.y = maxY;

                transformComponent.Transform.position = newPosition;
            }
        }
    }
}

