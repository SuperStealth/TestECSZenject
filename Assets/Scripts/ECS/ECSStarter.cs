using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace TestEcsZenject
{
    public sealed class ECSStarter : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;
        // Start is called before the first frame update
        private void Start()
        {
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

        }

        private void AddSystems()
        {
            systems.Add(new InitSystem());
            systems.Add(new PlayerInputSystem());
            systems.Add(new PlayerMovementSystem());
            systems.Add(new EnemySpawnSystem());
        }

        private void AddOneFrames()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            systems.Run();
        }

        private void OnDestroy()
        {
            if (systems != null) 
                return;
            
            systems.Destroy();
            systems = null;

            world.Destroy();
            world = null;
        }
    }
}