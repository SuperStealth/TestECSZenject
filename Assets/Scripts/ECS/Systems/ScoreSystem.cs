using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{  
    public sealed class ScoreSystem : IEcsInitSystem, IEcsRunSystem
    {
        private GameUI _gameUI;
        
        private EcsWorld _world;
        private EcsEntity _scoreEntity;
        private EcsFilter<IncreaseScoreEvent> _filter;

        public void Init()
        {
            _scoreEntity = _world.NewEntity();
            _scoreEntity.Get<ScoreComponent>().Score = 0;
        }

        public void Run()
        {
            foreach(var i in _filter)
            {
                _filter.GetEntity(i).Del<IncreaseScoreEvent>();
                ref var scoreComponent = ref _scoreEntity.Get<ScoreComponent>();
                scoreComponent.Score++;
                _gameUI.SetScore(scoreComponent.Score);
                if (scoreComponent.Score > PlayerPrefs.GetInt("highscore"))
                {
                    PlayerPrefs.SetInt("highscore", scoreComponent.Score);
                }
            }
        }
    }
}