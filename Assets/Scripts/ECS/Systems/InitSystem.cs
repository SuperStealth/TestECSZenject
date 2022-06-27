using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace TestEcsZenject
{
    public sealed class InitSystem : IEcsInitSystem
    {
        private EcsWorld _world;

        private GameBinds _gameBinds;

        public void Init()
        {
            var playerEntity = _world.NewEntity();
            
            ref var movable = ref playerEntity.Get<MovableComponent>();
            movable.Speed = _gameBinds.GameSettings.PlayerSpeed;
            
            ref var health = ref playerEntity.Get<HealthComponent>();
            health.Health = _gameBinds.GameSettings.PlayerHealth;

            ref var weapon = ref playerEntity.Get<WeaponComponent>();
            weapon.RateOfFire = _gameBinds.GameSettings.WeaponSpeed;
            weapon.Damage = _gameBinds.GameSettings.WeaponDamage;

            ref var transform = ref playerEntity.Get<TransformComponent>();
            var playerObject = Object.Instantiate(_gameBinds.Player);
            playerObject.GetComponent<EntityReference>().entity = playerEntity;
            transform.Transform = playerObject.transform;
            playerEntity.Get<PlayerTagComponent>();
            playerEntity.Get<InputComponent>();      
        }
    }
}