using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasingEnemy : MonoBehaviour
{

    public Transform player;
    public float speed = 5f;
    public float detectionRange = 30f;
    public float stopDistance = 1.5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < detectionRange && distance > stopDistance)
        {

            Vector2 dir = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        }
    }
    
}
