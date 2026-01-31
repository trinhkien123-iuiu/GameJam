using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player"))
        {
            Debug.Log("Collected");
            collision.GetComponent<PlayerProperties>().pass += 1;
            Destroy(this.gameObject);
        }
    }
}
