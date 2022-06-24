using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<PlayerTagComponent, InputComponent> inputFilter = null;

        public void Run()
        {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            var shooting = Input.GetButton("Fire");
            var switchingWeapon = Input.GetButton("Switch");
            foreach (var entity in inputFilter)
            {
                ref var inputComponent = ref inputFilter.Get2(entity);
                inputComponent.InputDirection = movement;
                inputComponent.IsShooting = shooting;
                inputComponent.ChangingWeapon = switchingWeapon;
            }
        }
    }
}