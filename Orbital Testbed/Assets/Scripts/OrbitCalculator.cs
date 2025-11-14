using System;
using UnityEngine;

public class OrbitCalculator : MonoBehaviour
{
    public float apogee;
    public float perigee;
    public float inclination;
    public float raan;
    public float trueAnomaly;
    public float argOfPerigee;

    public LineRenderer line;
    public Transform earth;

    float R_earth = 6371f;
    float scale = 0.0006f;
    void Start()
    {
        DrawOrbit();
    }

    void Update()
    {
        DrawOrbit();
    }

    void DrawOrbit() 
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

        int segmants = 360;
        line.positionCount = segmants;

        for(int i = 0; i < segmants; i++)
        {
            float nu = i * Mathf.Deg2Rad;
            float r = (a * (1 - e * e)) / (1 + e * Mathf.Cos(nu));

            float x_p = r * Mathf.Cos(nu);
            float y_p = r * Mathf.Sin(nu);
            Vector3 perifocal = new Vector3(x_p, y_p, 0);

            Vector3 eci = PerifocalToECI(perifocal, raan, inclination, argOfPerigee);

            line.SetPosition(i, eci * scale + earth.position);
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
