using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitPredictor : MonoBehaviour
{
    [SerializeField] private int predictionSteps = 200;
    [SerializeField] private float timeStep = 0.05f;
    [SerializeField] private float gravityStrength = 10f;
    [SerializeField] private Transform planet;

    private LineRenderer line;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        DrawOrbitPrediction();
    }

    private void DrawOrbitPrediction()
    {
        if (planet == null) return;

        Vector2 positon = rb.position;
        Vector2 velocity = rb.linearVelocity;

        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < predictionSteps; i++)
        {
            Vector2 direction = (Vector2)planet.position - positon;
            float distance = direction.magnitude;

            Vector2 gravity = direction.normalized * gravityStrength / (distance * distance);
            velocity += gravity * timeStep;
            positon += velocity * timeStep;

            points.Add(positon);
        }

        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());

    }
}
