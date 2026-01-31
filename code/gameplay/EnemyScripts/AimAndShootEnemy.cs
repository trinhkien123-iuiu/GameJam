using UnityEngine;

public class AimAndShootEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPos;

    public float delayTime = 1.0f;
    public float delayTimeBegin = 1.0f;

    private Transform player;
    private bool isDead;

    void Start()
    {
        isDead = GetComponentInParent<LongRangeEnemy>().isDead;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        isDead = GetComponentInParent<LongRangeEnemy>().isDead;
        if (isDead) return;
        Aim();
        Shoot();
    }

    void Aim()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    void Shoot()
    {
        if (GetComponentInParent<LongRangeEnemy>().isShooting == false)
        {
            return;
        }

        if (delayTime <= 0f)
        {
            Instantiate(bulletPrefab, spawnPos.position, transform.rotation);
            delayTime = delayTimeBegin;
        }
        else
        {
            delayTime -= Time.deltaTime;
        }
    }
}
