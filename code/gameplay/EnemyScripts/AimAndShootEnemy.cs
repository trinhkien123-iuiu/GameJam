using UnityEngine;

public class AimAndShootEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPos;

    public float delayTime = 1.0f;
    public float delayTimeBegin = 1.0f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
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
