using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestEcsZenject
{
    public class EnemySpawnSystem : IEcsRunSystem
    {
        private EcsWorld _world;

        private GameBinds _gameBinds;

        private int _lastAsteroidSpawnTime;

        [System.Obsolete]
        public void Run()
        {
            var enemyEntity = _world.NewEntity();

            ref var movable = ref enemyEntity.Get<MovableComponent>();
            var randomSpeed = Random.Range(_gameBinds.GameSettings.AsteroidMinSpeed, _gameBinds.GameSettings.AsteroidMaxSpeed);           
            movable.Speed = randomSpeed;

            ref var transform = ref enemyEntity.Get<TransformComponent>();
            var enemyObject = Object.Instantiate(_gameBinds.Asteroid);
            var randomSize = Random.Range(_gameBinds.GameSettings.AsteroidMinSize, _gameBinds.GameSettings.AsteroidMaxSize);
            enemyObject.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            transform.CharacterTransform = enemyObject.transform;

            enemyEntity.Get<EnemyTagComponent>();
        }
    }

}
