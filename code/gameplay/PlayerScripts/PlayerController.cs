using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    Vector2 moveDir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(h, v).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = moveDir * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("LowRangeEnemy"))
        //{
        //    gameObject.GetComponent<PlayerProperties>().TakeDamage(10f);
        //    Debug.Log("Player hit by LowRangeEnemy");
        //}
    }
}
