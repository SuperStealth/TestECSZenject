using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class ProjectileMoveSystem : IEcsRunSystem
    {
        private GameBinds _binds;
        
        private EcsFilter<BulletTagComponent,TransformComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformComponent = ref _filter.Get2(i);
                var speed = _binds.GameSettings.BulletSpeed;
                Vector3 positionDelta = new Vector3(speed * Time.deltaTime, 0f, 0f);
                transformComponent.Transform.position += positionDelta;
            }
        }
    }
}

