using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class LowRangeEnemy : MonoBehaviour
{
    public float health = 100f;
    private Transform player;
    public enum elements
    {
        Fire,
        Water,
        Earth
    }
    public elements currentElement;


    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float delayTime = 1.0f;
    public float delayTimeBegin = 1.0f;
    // Start is called before the first frame update

    elements RandomEnemy()
    {
        return (elements)Random.Range(0, System.Enum.GetValues(typeof(elements)).Length);
    }

    void Start()
    {
        currentElement = RandomEnemy();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(rb.position, player.position);

            Vector2 dir = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
   
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
