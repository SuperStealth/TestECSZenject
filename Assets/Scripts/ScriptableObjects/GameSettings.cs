using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestEcsZenject
{
    [CreateAssetMenu(fileName = "New game settings", menuName = "Game settings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private float playerHealth;
        [SerializeField] private float playerSpeed;

        [SerializeField] private float weaponDamage;
        [SerializeField] private float weaponSpeed;

        [SerializeField] private float laserDPS;

        [SerializeField] private float asteroidMinHealth;
        [SerializeField] private float asteroidMaxHealth;
        [SerializeField] private float asteroidMinSize;
        [SerializeField] private float asteroidMaxSize;
        [SerializeField] private float asteroidMinSpeed;
        [SerializeField] private float asteroidMaxSpeed;
        [SerializeField] private float asteroidMinAngle;
        [SerializeField] private float asteroidMaxAngle;

        public float PlayerHealth { get => playerHealth; }
        public float PlayerSpeed { get => playerSpeed; }
        public float WeaponDamage { get => weaponDamage; }
        public float WeaponSpeed { get => weaponSpeed; }
        public float LaserDPS { get => laserDPS; }
        public float AsteroidMinHealth { get => asteroidMinHealth; }
        public float AsteroidMaxHealth { get => asteroidMaxHealth; }
        public float AsteroidMinSize { get => asteroidMinSize; }
        public float AsteroidMaxSize { get => asteroidMaxSize; }
        public float AsteroidMinSpeed { get => asteroidMinSpeed; }
        public float AsteroidMaxSpeed { get => asteroidMaxSpeed; }
        public float AsteroidMinAngle { get => asteroidMinAngle; }
        public float AsteroidMaxAngle { get => asteroidMaxAngle; }
    }
}