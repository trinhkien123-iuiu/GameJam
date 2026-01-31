using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    GameObject bulletPrefab;
    private Camera mainCam;
    private Vector3 mousePos;
    public PlayerAnimation playerAnimation;
    public int magicType = 0;
    private int passCheck;
    

    public GameObject[] bullets;
    
    //Lấy element từ player
    private PlayerProperties playerProperties;


    [Header("Khoảng cách tối thiểu để đạn không dính player")]
    public Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        passCheck = this.GetComponentInParent<PlayerProperties>().pass;
        playerAnimation.setMagic(0);
        playerProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        passCheck = this.GetComponentInParent<PlayerProperties>().pass;
        if (Input.GetKey("1") && passCheck>=1)
        {
            magicType = 1;
            playerAnimation.setMagic(1);
            playerProperties.currentElement = PlayerProperties.ElementType.Fire;

        }
        else
        if (Input.GetKey("2") && passCheck>=2)
        {
            magicType = 2;
            playerAnimation.setMagic(2);
            playerProperties.currentElement = PlayerProperties.ElementType.Water;
        }
        else if (Input.GetKey("3") && passCheck>=3)
        {
            magicType = 3;
            playerAnimation.setMagic(3);
            playerProperties.currentElement = PlayerProperties.ElementType.Earth;
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

    public GameObject bulletDefault;

    public void Shoot()
    {
        if (passCheck>=1)
        {
            bulletPrefab = bullets[(int)playerProperties.currentElement];
        }
        else
        {
            bulletPrefab = bulletDefault;
        }
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDirection = (mousePos - transform.position).normalized;
        Instantiate(bulletPrefab, spawnPos.position, Quaternion.identity);
    }
}
