using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [Header("Ship Parameters")]
    [SerializeField] private float shipVelocity = 10f;
    [SerializeField] private float shipRotationSpeed = 1800f;
    [SerializeField] private float shipAcceleration = 10f;

    public Bullet_Spawn bulletPrefab;

    private Rigidbody2D rb;
    private bool isThrusting = false;
    private bool isAlive = true;

    private bool isShooting = false;
    private Vector2 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void OnThrust(InputValue value)
    {
        isThrusting = value.isPressed;
    }

    void OnRotate(InputValue value)
    {
        float rotationInput = value.Get<float>();
        if (isAlive && rotationInput != 0)
        {
            rb.AddTorque(-rotationInput * shipRotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (isAlive && isThrusting)
        {
            rb.AddForce(transform.up * shipAcceleration);
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, shipVelocity);
            isThrusting = false;
        }

        if (isAlive && isShooting)
        {
            isShooting = false;
        }
    }

    private void OnShoot(InputValue value)
    {
        if (isAlive)
        {
            Bullet_Spawn bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.Fire(this.transform.up);
            isShooting = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isAlive = false;
            startPosition = Vector2.zero;
            transform.position = startPosition;
            rb.angularVelocity = 0f;
            isAlive = true; 
        }
    }
    //give player I-frames for 2 seconds
}
