using UnityEngine;
using Zenject;
namespace TestEcsZenject
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject enemy;
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private ECSStarter gameStarter;

        public override void InstallBindings()
        {           
            Container.BindInstance(new GameBinds(player,enemy,gameSettings)).AsSingle();
        }
    }
}