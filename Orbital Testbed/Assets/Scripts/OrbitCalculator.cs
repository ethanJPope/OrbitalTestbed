using System;
using UnityEngine;

public class OrbitCalculator : MonoBehaviour
{
    [Header("Orbit Parts")]
    public float apogee;
    public float perigee;
    public float inclination;
    public float raan;
    public float trueAnomaly;
    public float argOfPerigee;

    [Header("Orbit References")]
    public LineRenderer line;
    public Transform earth;

    [Header("Orbit Data")]
    public Vector3[] orbitPoints;
    public float orbitalPeriod;
    public float[] radii;
    public float semiMajorAxis;
    float R_earth = 6371f;
    float mu = 398600.4418f;
    float scale = 0.0006f;
    void Start()
    {
        DrawOrbit();
    }

    public void DrawOrbit() 
    {
        if(perigee > apogee)
        {
            float temp = apogee;
            apogee = perigee;
            perigee = temp;
        }
        if(perigee < 0)
        {
            perigee = 0;
        }
        if(apogee < 0)
        {
            apogee = 0;
        }
        float r_a = apogee + R_earth;
        float r_p = perigee + R_earth;

        float a = (r_a + r_p) / 2f;
        float e = (r_a - r_p) / (r_a + r_p);

        orbitalPeriod = 2f * Mathf.PI * Mathf.Sqrt(a * a * a / mu);

        int segmants = 360;
        line.positionCount = segmants;
        
        orbitPoints = new Vector3[segmants];
        radii = new float[segmants];

        for (int i = 0; i < segmants; i++)
        {
            float nu = i * Mathf.Deg2Rad;
            float r = (a * (1 - e * e)) / (1 + e * Mathf.Cos(nu));
            radii[i] = r;

            float x_p = r * Mathf.Cos(nu);
            float y_p = r * Mathf.Sin(nu);
            Vector3 perifocal = new Vector3(x_p, y_p, 0);

            Vector3 eci = PerifocalToECI(perifocal, raan, inclination, argOfPerigee);

            Vector3 worldPos = eci * scale + earth.position;

            orbitPoints[i] = worldPos;
            line.SetPosition(i, worldPos);
        }
    }

    public Vector3 PerifocalToECI(Vector3 r_pf, float RAAN, float incl, float argPeri)
    {
        Quaternion q1 = Quaternion.AngleAxis(RAAN, Vector3.up);
        Quaternion q2 = Quaternion.AngleAxis(incl, Vector3.right);
        Quaternion q3 = Quaternion.AngleAxis(argPeri, Vector3.forward);

        Quaternion q = q1 * q2 * q3;

        Vector3 r_eci = q * r_pf;

        return r_eci;

    }
}
