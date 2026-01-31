using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour
{
    public float damage = 10f;
    private PlayerProperties playerProperties;
    public PlayerProperties.ElementType elementType;

    private void Start()
    {
        playerProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
        this.elementType = playerProperties.currentElement;
    }
}
