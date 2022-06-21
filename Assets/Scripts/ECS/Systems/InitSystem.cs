using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
namespace TestEcsZenject
{
    public class InitSystem : IEcsInitSystem
    {
        private EcsWorld _world;

        public void Init()
        {
            var player = _world.NewEntity();
            ref var playerInput = ref player.Get<InputComponent>();
        }
    }
}