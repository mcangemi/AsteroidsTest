using Unity.VisualScripting;
using UnityEngine;
using Aspawn = Asteroid_Spawn;
public class Asteroid_movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    private float scale;
    [SerializeField] private float speed = 1200f;
    [SerializeField] private float torque = 300f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scale = Random.Range(0.25f, 2.5f);
        transform.localScale = new Vector3(scale, scale, 1);
        rb.AddForce(new Vector2(Random.Range(0, speed), Random.Range(-speed, speed)));
        rb.AddTorque(Random.Range(-torque, torque));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            //Destroy(collision.gameObject);
            //Destroy(this.gameObject);
            Aspawn spawn = GameObject.Find("Main Camera").GetComponent<Aspawn>();
            spawn.currentAsteroids--;
        }
    }

}
