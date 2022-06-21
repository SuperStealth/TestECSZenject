using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
namespace TestEcsZenject
{
    public class ECSStarter : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;
        // Start is called before the first frame update
        private void Start()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);
            systems.Add(new InitSystem());
            systems.Init();
        }

        // Update is called once per frame
        private void Update()
        {
            systems.Run();
        }

        private void OnDestroy()
        {
            systems.Destroy();
            world.Destroy();
        }
    }
}