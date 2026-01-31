using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour
{
    public float health = 100f;
    public Image healthBar;
    public int pass = 0;

    //Nguyên tố
    public enum ElementType { Earth, Water, Fire, Default }
    public ElementType currentElement;

    public bool lockOldElements=false;

    public enum NewElementType { Earth, Water, Fire, Wood, Air, Lava, Default}
    public NewElementType currentNewElement;


    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100f;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        // Xử lý khi người chơi chết (ví dụ: phát hiệu ứng, tải lại cảnh, v.v.)
        Debug.Log("Player has died.");
    }
}
