using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public class GameOverSystem : IEcsRunSystem
    {
        private GameUI gameUI;
        
        private EcsFilter<PlayerTagComponent, TransformComponent, DestroyTagComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformComponent = ref _filter.Get2(i);
                Object.Destroy(transformComponent.Transform.gameObject);
                _filter.GetEntity(i).Destroy();
                gameUI.ShowUI(false);
                gameUI.ShowGameEnd(true);
            }
        }       
    }
}

