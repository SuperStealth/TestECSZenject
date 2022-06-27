using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestEcsZenject
{
    public class WeaponSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<InputComponent, WeaponComponent, TransformComponent> _filter;

        private GameBinds _gameBinds;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var isShooting = ref _filter.Get1(i).IsShooting;
                if (isShooting)
                {
                    ref var weaponComponent = ref _filter.Get2(i);
                    if (weaponComponent.LastShotTime + weaponComponent.RateOfFire < Environment.TickCount)
                    {
                        ref var transformComponent = ref _filter.Get3(i);
                        
                        CreateBullet(transformComponent.Transform.position);
                        weaponComponent.LastShotTime = Environment.TickCount;
                    }                   
                }
            }
        }

        private void CreateBullet(Vector3 position)
        {
            var bulletEntity = _world.NewEntity();
            bulletEntity.Get<BulletTagComponent>();

            ref var damageComponent = ref bulletEntity.Get<DamageComponent>();
            damageComponent.Damage = _gameBinds.GameSettings.WeaponDamage;


            ref var transform = ref bulletEntity.Get<TransformComponent>();

            var prefab = UnityEngine.Object.Instantiate(_gameBinds.Bullet);
            prefab.GetComponent<EntityReference>().entity = bulletEntity;
            transform.Transform = prefab.transform;
            transform.Transform.position = position;
        }
    }
}

