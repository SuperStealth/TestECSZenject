using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class GameOverSystem : IEcsRunSystem
    {
        private GameUI _gameUI;
        
        private EcsFilter<PlayerTagComponent, TransformComponent, DestroyTagComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformComponent = ref _filter.Get2(i);
                Object.Destroy(transformComponent.Transform.gameObject);

                var entity = _filter.GetEntity(i);
                if (entity.Has<LaserWeaponComponent>())
                {
                    ref var laserComponent = ref entity.Get<LaserWeaponComponent>();
                    Object.Destroy(laserComponent.LaserObject);
                    laserComponent.LaserObject = null;
                }

                entity.Destroy();
                _gameUI.ShowUI(false);
                _gameUI.ShowGameEnd(true);
            }
        }       
    }
}

