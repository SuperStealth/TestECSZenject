using UnityEngine;

namespace TestEcsZenject
{
    public sealed class SpawnTransforms
    {
        public Transform PlayerSpawn { get; }
        public Transform EnemySpawn { get; }
        public SpawnTransforms(Transform playerSpawn, Transform enemySpawn)
        {
            PlayerSpawn = playerSpawn;
            EnemySpawn = enemySpawn;
        }
    }
}