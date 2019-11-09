using UnityEngine;

namespace DefaultNamespace
{
    public class PlanetPullBearBehavior : MonoBehaviour
    {
        public Bear Bear;

        public float MaxForceCoefficient = 3f;

        void Update()
        {
            var differenceVector = Bear.transform.position - transform.position;
            var normalized = differenceVector.normalized;
            var magnitude = differenceVector.magnitude;

            if (magnitude < MaxForceCoefficient)
            {
                magnitude = 1- magnitude/MaxForceCoefficient;

                var force = normalized * magnitude;
                Bear.ApplyForce(force);
            }
        }
    }
}