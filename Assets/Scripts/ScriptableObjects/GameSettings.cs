using UnityEngine;

namespace TestEcsZenject
{
    [CreateAssetMenu(fileName = "New game settings", menuName = "Game settings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private float _playerHealth;
        [SerializeField] private float _playerSpeed;

        [SerializeField] private float _weaponDamage;
        [SerializeField] private float _weaponSpeed;
        [SerializeField] private float _bulletSpeed;

        [SerializeField] private float _laserDPS;

        [SerializeField] private float _asteroidSpawnDelay;
        [SerializeField] private float _asteroidDamage;
        [SerializeField] private float _asteroidMinHealth;
        [SerializeField] private float _asteroidMaxHealth;
        [SerializeField] private float _asteroidMinSize;
        [SerializeField] private float _asteroidMaxSize;
        [SerializeField] private float _asteroidMinSpeed;
        [SerializeField] private float _asteroidMaxSpeed;
        [SerializeField] private float _asteroidMinY;
        [SerializeField] private float _asteroidMaxY;

        public float PlayerHealth { get => _playerHealth; }
        public float PlayerSpeed { get => _playerSpeed; }

        public float WeaponDamage { get => _weaponDamage; }
        public float WeaponSpeed { get => _weaponSpeed; }
        public float BulletSpeed { get => _bulletSpeed; }
        public float LaserDPS { get => _laserDPS; }

        public float AsteroidMinHealth { get => _asteroidMinHealth; }
        public float AsteroidMaxHealth { get => _asteroidMaxHealth; }
        public float AsteroidMinSize { get => _asteroidMinSize; }
        public float AsteroidMaxSize { get => _asteroidMaxSize; }
        public float AsteroidMinSpeed { get => _asteroidMinSpeed; }
        public float AsteroidMaxSpeed { get => _asteroidMaxSpeed; }
        public float AsteroidMinY { get => _asteroidMinY; }
        public float AsteroidMaxY { get => _asteroidMaxY; }
        public float AsteroidSpawnDelay { get => _asteroidSpawnDelay; }
        public float AsteroidDamage { get => _asteroidDamage; }
    }
}