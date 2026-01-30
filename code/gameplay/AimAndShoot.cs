using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    GameObject bulletPrefab;
    private Camera mainCam;
    private Vector3 mousePos;

    public enum bulletType //Loai dan
    {
        fire,
        water,
        earth
    }

    public GameObject[] bullets;

    public bulletType currentBulletType;


    [Header("Khoảng cách tối thiểu để đạn không dính player")]
    public Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            currentBulletType = bulletType.fire;
        }
        else
        if (Input.GetKey("2"))
        {
            currentBulletType = bulletType.water;
        }
        else if (Input.GetKey("3"))
        {
            currentBulletType = bulletType.earth;
        }
        Aim();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Aim()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void Shoot()
    {
        bulletPrefab = bullets[(int)currentBulletType];
        Debug.Log((int)currentBulletType);
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDirection = (mousePos - transform.position).normalized;
        Instantiate(bulletPrefab, spawnPos.position, Quaternion.identity);
    }
}
