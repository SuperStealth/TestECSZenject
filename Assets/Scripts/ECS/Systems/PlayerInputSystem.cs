using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTagComponent, InputComponent> _inputFilter;

        public void Run()
        {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            var shooting = Input.GetButton("Fire");
            var switchingWeapon = Input.GetButton("Switch");

            foreach (var entity in _inputFilter)
            {
                ref var inputComponent = ref _inputFilter.Get2(entity);
                inputComponent.InputDirection = movement;
                inputComponent.IsShooting = shooting;
                inputComponent.ChangingWeapon = switchingWeapon;
            }
        }
    }
}