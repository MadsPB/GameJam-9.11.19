using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BearCollisionDetector : MonoBehaviour
    {
        public Bear Bear;
        public GameManager GameManager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Planet>() != null)
            {
                var planet = other.GetComponent<Planet>();
                GameManager.HandleBearHitPlanet(Bear, planet);
            }
        }
    }
}