using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    [SerializeField] private float gravityStrength = 10f;

    void FixedUpdate() {
        foreach (RocketController rocket in FindObjectsOfType<RocketController>())
        {
            Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
            Vector2 direction = (Vector2)transform.position - rb.position;
            rb.AddForce(direction.normalized * gravityStrength / Mathf.Pow(direction.magnitude, 1.8f));

        }
    }
}
