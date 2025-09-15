using Unity.VisualScripting;
using UnityEngine;

public class Bullet_Spawn : MonoBehaviour
{
    private float velocity = 800f;
    private Rigidbody2D rb;
    private float lifeTime = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Fire(Vector2 direction)
    {
        rb.AddForce(direction * velocity);
        Destroy(this.gameObject, this.lifeTime);
    }
    //bullet asteroid collision (if asteroid bigger than 1 scale split in half, if smaller than 1 scale destroy it and destroy bullet)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
    //OPTIONAL: add point system
}
