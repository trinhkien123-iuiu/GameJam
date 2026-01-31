using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class LongRangeEnemy : MonoBehaviour
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
    public bool isShooting = false;
    public bool isDead = false;

    [Header("Tầm nhìn và tầm bắn")]
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float lookDis = 20f;

    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float delayTime = 1.0f;
    public float delayTimeBegin = 1.0f;

    public float diff = 10f;

    public GameObject hitBoxCollect;

    elements RandomEnemy()
    {
        return (elements)Random.Range(0, System.Enum.GetValues(typeof(elements)).Length);
    }

    void Start()
    {
        hitBoxCollect = this.gameObject.GetComponentInChildren<CollectTrigger>().gameObject;
        if (currentElement == elements.Fire)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (currentElement == elements.Water)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (currentElement == elements.Earth)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            if (player == null) return;

            float distance = Vector2.Distance(rb.position, player.position);
            if (distance > lookDis)
            {
                // Player quá xa → đứng yên
                rb.velocity = Vector2.zero;
            }
            else if (distance > attackRange)
            {
                // Trong tầm nhìn → chạy lại
                Vector2 dir = (player.position - transform.position).normalized;
                rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                // Trong tầm bắn → đứng yên và bắn
                rb.velocity = Vector2.zero;
                isShooting = true;
            }
        }
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
        isDead = true;
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        hitBoxCollect.GetComponent<Collider2D>().enabled = true;
    }
}
