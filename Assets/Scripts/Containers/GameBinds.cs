using UnityEngine;

namespace TestEcsZenject
{
    public sealed class GameBinds
    {
        public GameObject Player { get; }
        public GameObject Asteroid { get; }
        public GameObject Bullet { get; }
        public GameSettings GameSettings { get; }
        public GameObject Laser { get; }

        public GameBinds(GameObject player, GameObject asteroid, GameObject bullet, GameObject laser, GameSettings settings)
        {
            Player = player;
            Asteroid = asteroid;
            Bullet = bullet;
            Laser = laser;
            GameSettings = settings;
        }
    }
}