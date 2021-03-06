using UnityEngine;
using Zenject;

namespace TestEcsZenject
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject enemy;
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject laser;
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private ECSStarter gameStarter;
        [SerializeField] private Transform playerSpawn;
        [SerializeField] private Transform enemySpawn;

        public override void InstallBindings()
        {           
            Container.BindInstance(new GameBinds(player, enemy, bullet, laser, gameSettings)).AsSingle();
            Container.BindInstance(new SpawnTransforms(playerSpawn, enemySpawn)).AsSingle();
        }
    }
}