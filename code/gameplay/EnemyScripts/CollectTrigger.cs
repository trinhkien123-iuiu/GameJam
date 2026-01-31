using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectTrigger : MonoBehaviour
{
    public float fallAmount;
    public Transform enemyPos;
    public bool isFallen = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFallen)
        {
            Debug.Log("Trigger entered by: " + collision.gameObject.name);
        }
    }

    public void Fall()
    {
        transform.DOMoveY(transform.position.y - fallAmount, 0.5f).SetEase(Ease.InBack);
    }
}
