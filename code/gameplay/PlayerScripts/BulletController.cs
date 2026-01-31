
﻿using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Camera mainCam;
    Vector3 direction;
    public float speed = 10f;
    //Không biết, đừng xóa;
    public float diff = -35f;
    public int magic = 0;
    private Animator animator;

    private BulletProperties bulletProperties;

 
    void Start()
    {
        bulletProperties = GetComponent<BulletProperties>();
        mainCam = Camera.main;

        Vector3 mouse = Input.mousePosition;
        mouse.z = -mainCam.transform.position.z;
        Vector3 mousePos = mainCam.ScreenToWorldPoint(mouse);

        direction = (mousePos - transform.position).normalized;

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + diff);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LongRangeEnemy"))
        {
            LongRangeEnemy enemyProperties = collision.gameObject.GetComponent<LongRangeEnemy>();
            if (enemyProperties != null)
            {
                if (enemyProperties.currentElement == LongRangeEnemy.elements.Fire && bulletProperties.elementType == PlayerProperties.ElementType.Water ||
                    enemyProperties.currentElement == LongRangeEnemy.elements.Water && bulletProperties.elementType == PlayerProperties.ElementType.Earth ||
                    enemyProperties.currentElement == LongRangeEnemy.elements.Earth && bulletProperties.elementType == PlayerProperties.ElementType.Fire)
                {
                    // Yếu điểm
                    enemyProperties.TakeDamage(bulletProperties.damage * 2);
                }
                else if (enemyProperties.currentElement == LongRangeEnemy.elements.Fire && bulletProperties.elementType == PlayerProperties.ElementType.Earth ||
                         enemyProperties.currentElement == LongRangeEnemy.elements.Water && bulletProperties.elementType == PlayerProperties.ElementType.Fire ||
                         enemyProperties.currentElement == LongRangeEnemy.elements.Earth && bulletProperties.elementType == PlayerProperties.ElementType.Water)
                {
                    // Kháng
                    enemyProperties.TakeDamage(bulletProperties.damage / 2);
                }
                else
                {
                    // Bình thường
                    enemyProperties.TakeDamage(bulletProperties.damage);
                }
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("LowRangeEnemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        }
    }

