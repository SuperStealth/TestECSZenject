using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public class AsteroidCollisionHandler : EntityReference
    {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var other = collision.collider.gameObject;
            if (other.tag != "Enemy")
            {
                ref var collisionEvent = ref Entity.Get<CollisionEnterEvent>();
                collisionEvent.collider = other;
            }             
        }
    }
}