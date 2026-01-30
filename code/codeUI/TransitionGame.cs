using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public GameObject transitionRoot;     // Panel TransitionRoot
    public RectTransform maskLeft;        // Image MaskLeft
    public RectTransform maskRight;       // Image MaskRight

    public float duration = 0.5f;

    Vector2 leftOpenPos, leftClosedPos;
    Vector2 rightOpenPos, rightClosedPos;

    void Awake()
    {
        // Ghi lại vị trí "đóng" (vị trí hiện tại bạn đặt trong editor)
        leftClosedPos = maskLeft.anchoredPosition;
        rightClosedPos = maskRight.anchoredPosition;

        // Tính vị trí "mở": kéo ra ngoài màn hình theo chiều ngang
        float wL = maskLeft.rect.width;
        float wR = maskRight.rect.width;

        leftOpenPos = leftClosedPos + Vector2.left * (wL + 50f);
        rightOpenPos = rightClosedPos + Vector2.right * (wR + 50f);

        // Lúc đầu để ở trạng thái mở (ra ngoài)
        maskLeft.anchoredPosition = leftOpenPos;
        maskRight.anchoredPosition = rightOpenPos;

        transitionRoot.SetActive(false);
    }

    public void Play()
    {
        StartCoroutine(CoPlay());
    }

    IEnumerator CoPlay()
    {
        transitionRoot.SetActive(true);

        float t = 0f;
        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            float k = Mathf.Clamp01(t / duration);
            // ease nhẹ cho mượt
            k = k * k * (3f - 2f * k);

            maskLeft.anchoredPosition = Vector2.Lerp(leftOpenPos, leftClosedPos, k);
            maskRight.anchoredPosition = Vector2.Lerp(rightOpenPos, rightClosedPos, k);

            yield return null;
        }

        SceneManager.LoadScene(0);
    }
}
