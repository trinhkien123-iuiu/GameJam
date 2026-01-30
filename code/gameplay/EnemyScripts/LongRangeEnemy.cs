using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy : MonoBehaviour
{
    private Transform player;

    [Header("Tầm nhìn và tầm bắn")]
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float lookDis = 20f;

    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float delayTime = 1.0f;
    public float delayTimeBegin = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(rb.position, player.position);

        if (distance <= attackRange)
        {
            rb.velocity = Vector2.zero;
            return; // 🚨 cực quan trọng
        }

        if (distance <= lookDis)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
