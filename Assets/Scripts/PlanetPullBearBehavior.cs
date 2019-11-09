using UnityEngine;

namespace DefaultNamespace
{
    public class PlanetPullBearBehavior : MonoBehaviour
    {
        public Bear Bear;

        public float MaxForceCoefficient = 10f;

        void Update()
        {
            var differenceVector = Bear.transform.position - transform.position;
            var normalized = differenceVector.normalized;
            var magnitude = differenceVector.magnitude;
            magnitude = Mathf.Min(MaxForceCoefficient, magnitude);
            magnitude = MaxForceCoefficient - magnitude;

            var force = normalized * magnitude;
            Bear.ApplyForce(force);
        }
    }
}