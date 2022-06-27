using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public sealed class WeaponSwitchSystem : IEcsRunSystem
    {
        private GameBinds _binds;
        
        private EcsFilter<PlayerTagComponent, InputComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var input = ref _filter.Get2(i);
                if (input.ChangingWeapon)
                {
                    var entity = _filter.GetEntity(i);
                    if (entity.Has<ProjectileWeaponComponent>())
                    {
                        entity.Del<ProjectileWeaponComponent>();
                        ref var laser = ref entity.Get<LaserWeaponComponent>();
                        laser.DPS = _binds.GameSettings.LaserDPS;
                        laser.LaserObject = Object.Instantiate(_binds.Laser);
                        laser.LaserObject.SetActive(false);
                    }
                    else
                    {
                        ref var laser = ref entity.Get<LaserWeaponComponent>();
                        Object.Destroy(laser.LaserObject);
                        entity.Del<LaserWeaponComponent>();
                        ref var projectileWeapon = ref entity.Get<ProjectileWeaponComponent>();
                        projectileWeapon.RateOfFire = _binds.GameSettings.WeaponSpeed;
                        projectileWeapon.Damage = _binds.GameSettings.WeaponDamage;
                    }
                }
            }
        }
    }
}