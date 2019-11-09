using UnityEngine;

namespace DefaultNamespace
{
    public class PlanetPullBearBehavior : MonoBehaviour
    {
        public Bear Bear;
        public float MaxDistance = 3f;

        void Update()
        {
            if (GameManager.didShoot)
            {
                var differenceVector = Bear.transform.position - transform.position;
                var normalized = differenceVector.normalized;
                var magnitude = differenceVector.magnitude;

                if (magnitude < MaxDistance)
                {
                    magnitude = 1 - magnitude / MaxDistance;

                    var force = normalized * magnitude;
                    Bear.ApplyForce(force);
                }
            }
        }
    }
}