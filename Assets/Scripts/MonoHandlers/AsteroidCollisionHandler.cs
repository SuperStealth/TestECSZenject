using Leopotam.Ecs;
using UnityEngine;

namespace TestEcsZenject
{
    public class AsteroidCollisionHandler : MonoBehaviour
    {
        public EcsEntity entity;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var other = collision.collider.gameObject;
            if (other.tag != "Enemy")
            {
                ref var collisionEvent = ref entity.Get<CollisionEnterEvent>();
                collisionEvent.collider = other;
            }             
        }
    }
}


