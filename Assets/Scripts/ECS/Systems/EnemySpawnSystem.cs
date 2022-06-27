using Leopotam.Ecs;
using System;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class EnemySpawnSystem : IEcsRunSystem
    {
        private EcsWorld _world;

        private GameBinds _gameBinds;

        private SpawnTransforms _spawnTransforms;

        private int _lastAsteroidSpawnTime = 0;

        public void Run()
        {
            if (_lastAsteroidSpawnTime + _gameBinds.GameSettings.AsteroidSpawnDelay < Environment.TickCount)
            {
                SpawnAsteroid();
                _lastAsteroidSpawnTime = Environment.TickCount;
            }
        }

        private void SpawnAsteroid()
        {
            var enemyEntity = _world.NewEntity();
            var enemyObject = UnityEngine.Object.Instantiate(_gameBinds.Asteroid);

            enemyObject.GetComponent<AsteroidCollisionHandler>().entity = enemyEntity;
            ref var movable = ref enemyEntity.Get<MovableComponent>();
            var randomSpeed = UnityEngine.Random.Range(_gameBinds.GameSettings.AsteroidMinSpeed, _gameBinds.GameSettings.AsteroidMaxSpeed);
            movable.Speed = randomSpeed;

            ref var health = ref enemyEntity.Get<HealthComponent>();
            var randomHealth = UnityEngine.Random.Range(_gameBinds.GameSettings.AsteroidMinHealth, _gameBinds.GameSettings.AsteroidMaxHealth);
            health.Health = randomHealth;

            ref var damageComponent = ref enemyEntity.Get<DamageComponent>();
            damageComponent.Damage = _gameBinds.GameSettings.AsteroidDamage;

            ref var transform = ref enemyEntity.Get<TransformComponent>();
            var randomSize = UnityEngine.Random.Range(_gameBinds.GameSettings.AsteroidMinSize, _gameBinds.GameSettings.AsteroidMaxSize);
            enemyObject.transform.localScale = new Vector3(randomSize, randomSize, randomSize);

            var randomY = UnityEngine.Random.Range(_gameBinds.GameSettings.AsteroidMinY, _gameBinds.GameSettings.AsteroidMaxY);
            enemyObject.transform.position = _spawnTransforms.EnemySpawn.position + new Vector3(0f, randomY, 0f);

            transform.Transform = enemyObject.transform;
            enemyEntity.Get<EnemyTagComponent>();
        }
    }

}
