using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace TestEcsZenject
{
    public sealed class ECSStarter : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;

        [Inject] private GameBinds _gameBinds;
        [Inject] private SpawnTransforms _spawnTransforms;

        // Start is called before the first frame update
        private void Start()
        {
            ClearWorld();
            
            world = new EcsWorld();
            systems = new EcsSystems(world);

            AddInjections();
            AddOneFrames();
            AddSystems();

            systems.ConvertScene();
            
            systems.Init();
        }

        private void AddInjections()
        {
            systems.Inject(_gameBinds);
            systems.Inject(_spawnTransforms);
        }

        private void AddSystems()
        {
            systems.Add(new InitSystem());
            systems.Add(new PlayerInputSystem());
            systems.Add(new PlayerMovementSystem());
            systems.Add(new EnemySpawnSystem());
            systems.Add(new EnemyMoveSystem());
            systems.Add(new EnemyDestroySystem());
            systems.Add(new WeaponSystem());
            systems.Add(new ProjectileMoveSystem());
            systems.Add(new BulletDespawnSystem()); 
        }

        private void AddOneFrames()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            systems?.Run();
        }

        private void ClearWorld()
        {
            if (systems == null)
                return;

            systems.Destroy();
            systems = null;

            world.Destroy();
            world = null;
        }

        private void OnDestroy()
        {
            ClearWorld();
        }
    }
}