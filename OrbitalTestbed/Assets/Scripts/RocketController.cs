using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] private float thrustPower = 5f;
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float fuel = 100f;

    private Rigidbody2D rb;
    private bool isThrusting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
    }

    void FixedUpdate()
    {
        if (isThrusting)
        {
            rb.AddForce(transform.up * thrustPower);
            fuel -= Time.deltaTime * 5f;
        }
        else
        {
            rb.linearVelocity *= 0.9995f;
        }
    }
    void Update()
    {
        
        float rotationInput = -Input.GetAxis("Horizontal");
        rb.MoveRotation(rb.rotation + rotationInput * rotationSpeed * Time.deltaTime);

        isThrusting = Input.GetKey(KeyCode.UpArrow) && fuel > 0;
    }
}
