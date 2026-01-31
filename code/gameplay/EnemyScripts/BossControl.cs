using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{

public class BossController : MonoBehaviour
{
    public GameObject[] smashHitBoxes;
    public GameObject smashStandHitBox;
    public GameObject[] smashDirtHitBoxes;

    [Header("Smash Attack Settings")]
    public float delayTimer = 3f;
    public float currentDelay = 0f;
    public float smashDuration = 5f; // Thời gian duy trì hitbox


    IEnumerator PerformStandSmashAttack()
    {
        smashStandHitBox.SetActive(true);
        // 2. Tạm dừng Coroutine trong X giây (Game vẫn chạy bình thường)
        yield return new WaitForSeconds(smashDuration);

        // 3. Tắt toàn bộ hitbox
        foreach (GameObject hitBox in smashHitBoxes)
        {
            hitBox.SetActive(false);
        }
    }

    IEnumerator PerformDirtSmashAttack()
    {
        foreach (GameObject hitBox in smashDirtHitBoxes)
        {
            hitBox.SetActive(true);
        }
        // 2. Tạm dừng Coroutine trong X giây (Game vẫn chạy bình thường)
        yield return new WaitForSeconds(smashDuration);

        // 3. Tắt toàn bộ hitbox
        foreach (GameObject hitBox in smashDirtHitBoxes)
        {
            hitBox.SetActive(false);
        }
    }
}
}
