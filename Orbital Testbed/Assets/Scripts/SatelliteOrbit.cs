using UnityEngine;

public class SatelliteOrbit : MonoBehaviour
{
    public OrbitCalculator orbitCalculator;
    public float speedMultiplier = 1f;

    void Update()
    {
        float normalized = (Time.time * speedMultiplier % orbitCalculator.orbitalPeriod) / orbitCalculator.orbitalPeriod;

        float index = (normalized * (orbitCalculator.orbitPoints.Length - 1));

        int indexA = (int)(index);
        int indexB = (indexA + 1) % orbitCalculator.orbitPoints.Length;
        float t = index - indexA;

        transform.position = Vector3.Lerp(orbitCalculator.orbitPoints[indexA], orbitCalculator.orbitPoints[indexB], t);
    }
}
