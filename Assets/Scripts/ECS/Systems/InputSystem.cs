using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    private EcsWorld _world;
    private EcsFilter<InputComponent> _inputFilter;

    public void Run()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var shooting = Input.GetButton("Fire");
        var switchingWeapon = Input.GetButton("Switch");
        foreach(var entity in _inputFilter)
        {
            ref var inputComponent = ref _inputFilter.Get1(entity);
            inputComponent.InputDirection = movement;
            inputComponent.IsShooting = shooting;
            inputComponent.ChangingWeapon = switchingWeapon;
            Debug.Log(inputComponent.InputDirection);
        }
    }
}
