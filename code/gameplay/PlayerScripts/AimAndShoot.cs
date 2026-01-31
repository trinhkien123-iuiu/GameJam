using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Camera mainCam;
    private Vector3 mousePos;
    public PlayerAnimation playerAnimation;
    public int magicType = 0;
    private int passCheck;
    

    public GameObject[] bullets;
    
    //Lấy element từ player
    private PlayerProperties playerProperties;

    bool checkChanged = false;
    int index;
    


    [Header("Khoảng cách tối thiểu để đạn không dính player")]
    public Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        elementUI = GameObject.FindGameObjectsWithTag("elementsUI");
        Debug.Log(elementUI.Length);
        index = 0;
        ElementList.Clear();
        checkChanged=false;
        passCheck = this.GetComponentInParent<PlayerProperties>().pass;
        playerAnimation.setMagic(0);
        playerProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerProperties.lockOldElements = true; //Tạm thời khóa để test cơ chế mới
    }

    List<int> ElementList = new List<int>();
    public GameObject[] elementUI;

    // Update is called once per frame
    void Update()
    {
        if (!playerProperties.lockOldElements)
        {
            passCheck = this.GetComponentInParent<PlayerProperties>().pass;
            if (Input.GetKey("1") && passCheck >= 1)
            {
                magicType = 1;
                playerAnimation.setMagic(1);
                playerProperties.currentElement = PlayerProperties.ElementType.Fire;
                checkChanged = true;
            }
            else
            if (Input.GetKey("2") && passCheck >= 2)
            {
                magicType = 2;
                playerAnimation.setMagic(2);
                playerProperties.currentElement = PlayerProperties.ElementType.Water;
                checkChanged = true;
            }
            else if (Input.GetKey("3") && passCheck >= 3)
            {
                magicType = 3;
                playerAnimation.setMagic(3);
                playerProperties.currentElement = PlayerProperties.ElementType.Earth;
                checkChanged = true;
            }
        }
        else
        {
            if (Input.GetKeyDown("1")|| Input.GetKeyDown("2") || Input.GetKeyDown("3"))
            {
                int input = Input.GetKeyDown("1") ? 1 : (Input.GetKeyDown("2") ? 2 : 3);
                if (ElementList.Count <2)
                {
                    ElementList.Add(input);
                    if (input == 1)
                    {
                        elementUI[index].GetComponent<SpriteRenderer>().color = Color.black;
                    }
                    else if (input == 2)
                    {
                        elementUI[index].GetComponent<SpriteRenderer>().color = Color.blue;
                    }
                    else if (input == 3)
                    {
                        elementUI[index].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    index++;
                }
                else
                {
                    ElementList.Clear();
                    index = 0;
                    for (int i = 0; i < elementUI.Length; i++)
                    {
                        elementUI[i].GetComponent<SpriteRenderer>().color = Color.white;
                    }
                    ElementList.Add(input);
                    if (input == 1)
                    {
                        elementUI[index].GetComponent<SpriteRenderer>().color = Color.black;
                    }
                    else if (input == 2)
                    {
                        elementUI[index].GetComponent<SpriteRenderer>().color = Color.blue;
                    }
                    else if (input == 3)
                    {
                        elementUI[index].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    index++;
                }
            }
            if (ElementList.Count == 2)
            {
                if (ElementList[0] == 1 && ElementList[1] == 1)
                {
                    playerAnimation.setMagic(1);
                    playerProperties.currentNewElement = PlayerProperties.NewElementType.Earth;
                }
                if (ElementList[0] == 2 && ElementList[1] == 2)
                {
                    playerAnimation.setMagic(2);
                    playerProperties.currentNewElement = PlayerProperties.NewElementType.Water;
                }
                if (ElementList[0] == 3 && ElementList[1] == 3)
                {
                    playerAnimation.setMagic(3);
                    playerProperties.currentNewElement = PlayerProperties.NewElementType.Fire;
                }
                if (ElementList.Contains(1) && ElementList.Contains(2))
                {
                    playerProperties.currentNewElement = PlayerProperties.NewElementType.Wood;
                }
                if (ElementList.Contains(2) && ElementList.Contains(3))
                {
                    playerProperties.currentNewElement = PlayerProperties.NewElementType.Air;
                }
                if (ElementList.Contains(1) && ElementList.Contains(3))
                {
                    playerProperties.currentNewElement = PlayerProperties.NewElementType.Lava;
                }
            }
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
        if (!playerProperties.lockOldElements)
        {
            if (passCheck >= 1 && checkChanged == true)
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
        else
        {
            if (ElementList.Count == 2)
            {
                bulletPrefab = bullets[(int)playerProperties.currentNewElement];
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
}
