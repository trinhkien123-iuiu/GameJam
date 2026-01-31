using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour
{
    Camera mainCam;
    Vector3 direction;
    public float speed1 = 10f;
    //Không biết, đừng xóa;
    public float diff1 = 0f;
    private Transform player;
    private BulletProperties bulletProperties; 

    void Start()
    {
        bulletProperties = GetComponent<BulletProperties>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        direction = (player.position - transform.position).normalized;

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + diff1);
    }

    void Update()
    {
        transform.position += direction * speed1 * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerProperties>().TakeDamage(10f);
        }
    }

}
