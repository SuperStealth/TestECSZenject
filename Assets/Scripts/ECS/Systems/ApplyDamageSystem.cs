using Leopotam.Ecs;

namespace TestEcsZenject
{
    public class ApplyDamageSystem : IEcsRunSystem
    {
        private EcsFilter<ReceivedDamageEvent, HealthComponent> _filter;

        public void Run()
        {
            foreach(var i in _filter)
            {
                _filter.Get2(i).Health -= _filter.Get1(i).Damage;
            }
        }
    }
}