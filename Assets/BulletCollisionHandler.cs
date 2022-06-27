using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestEcsZenject
{
    public class BulletCollisionHandler : MonoBehaviour
    {
        public EcsEntity entity;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var other = collision.otherCollider.gameObject;
            if (other.tag != "Player")
            {
                ref var collisionEvent = ref entity.Get<CollisionEnterEvent>();
                collisionEvent.collider = other;
            }      
        }
    }
}


