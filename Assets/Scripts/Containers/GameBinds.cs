using UnityEngine;

namespace TestEcsZenject
{
    public sealed class GameBinds
    {
        public GameObject Player { get; }
        public GameObject Asteroid { get; }
        public GameObject Bullet { get; }
        public GameSettings GameSettings { get; }
        public GameBinds(GameObject player, GameObject asteroid, GameObject bullet, GameSettings settings)
        {
            Player = player;
            Asteroid = asteroid;
            Bullet = bullet;
            GameSettings = settings;
        }
    }
}