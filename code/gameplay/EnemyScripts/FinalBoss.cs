using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public float health = 500f;
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
    MiniBossAnim miniBossAnim;
    public float delayTime = 1.0f;
    public float delayTimeBegin = 1.0f;

    public float diff = 10f;

    //public GameObject hitBoxCollect;

    elements RandomEnemy()
    {
        return (elements)Random.Range(0, System.Enum.GetValues(typeof(elements)).Length);
    }

    void Start()
    {
      //  hitBoxCollect = this.gameObject.GetComponentInChildren<CollectTrigger>().gameObject;
       
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        miniBossAnim = GetComponent<MiniBossAnim>();
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            if (player == null) return;

            float distance = Vector2.Distance(rb.position, player.position);
            if (distance > lookDis)
            {
                rb.velocity = Vector2.zero;
                miniBossAnim.AnimIdle();
            }
            else
            {
                // đứng yên và bắn
                rb.velocity = Vector2.zero;
                isShooting = true;
                miniBossAnim.AnimAttack1();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        miniBossAnim.AnimDie();
        yield return new WaitForSeconds(0.7f);
        isDead = true;
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        //hitBoxCollect.GetComponent<Collider2D>().enabled = true;
        //hitBoxCollect.GetComponent<SpriteRenderer>().enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.layer == 10)
        {
            TakeDamage(10f);
            Debug.Log("Player hit FinalBoss!");
        }
    }

}
