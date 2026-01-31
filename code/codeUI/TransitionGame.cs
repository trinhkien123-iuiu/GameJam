using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurtainMaskTransition : MonoBehaviour
{
    [Header("Refs")]
    public RectTransform root;
    public RectTransform maskLeft;
    public RectTransform maskRight;
    public Image black;

    [Header("Timing")]
    public float closeDuration = 0.55f;
    public float openDuration = 0.55f;

    [Header("Motion")]
    public float rotateDegrees = 180f;    
    public float extraOffscreen = 250f;    
    [Header("Black")]
    public float blackMaxAlpha = 1f;

        float leftClosedX, rightClosedX;
    float leftOpenX, rightOpenX;
    float leftStartX, rightStartX;     // vị trí lúc bắt đầu (ngoài màn hình đúng phía)
    float leftEndX, rightEndX;         // vị trí kết thúc "cross" (ngoài màn hình phía đối diện)


    void Awake()
    {

        float halfW = root.rect.width * 0.5f;

        // start: mỗi mask nằm ngoài màn hình phía của nó
        leftStartX  = -halfW - extraOffscreen;
        rightStartX =  halfW + extraOffscreen;

        // end: mỗi mask kết thúc ở phía đối diện (cross)
        leftEndX  =  halfW + extraOffscreen;
        rightEndX = -halfW - extraOffscreen;

        SetBlackAlpha(0f);
        SetMasksX(leftStartX, rightStartX);
        SetMaskRotation(0f);

    }

    public void StartToScene(string sceneName)
    {
        StartCoroutine(CoTransition(sceneName));
    }

    IEnumerator CoTransition(string sceneName)
    {
        yield return Close();

        yield return SceneManager.LoadSceneAsync(sceneName);

        yield return Open();

        Destroy(gameObject);
    }

    IEnumerator Close()
    {
        float t = 0f;
        while (t < closeDuration)
        {
            t += Time.unscaledDeltaTime;
            float k = Ease01(t / closeDuration);

            float lx = Mathf.Lerp(leftStartX, leftEndX, k);
            float rx = Mathf.Lerp(rightStartX, rightEndX, k);
            SetMasksX(lx, rx);

            float rot = rotateDegrees * k;
            maskLeft.localRotation = Quaternion.Euler(0, 0, +rot);
            maskRight.localRotation = Quaternion.Euler(0, 0, -rot);

            SetBlackAlpha(Mathf.Lerp(0f, blackMaxAlpha, k));
            yield return null;
        }

        SetMasksX(leftEndX, rightEndX);
        SetBlackAlpha(blackMaxAlpha);
    }


        IEnumerator Open()
    {
        float t = 0f;
        while (t < openDuration)
        {
            t += Time.unscaledDeltaTime;
            float k = Ease01(t / openDuration);

            float lx = Mathf.Lerp(leftEndX, leftStartX, k);
            float rx = Mathf.Lerp(rightEndX, rightStartX, k);
            SetMasksX(lx, rx);

            float rot = rotateDegrees * k;
            maskLeft.localRotation = Quaternion.Euler(0, 0, +rot);
            maskRight.localRotation = Quaternion.Euler(0, 0, -rot);

            SetBlackAlpha(Mathf.Lerp(blackMaxAlpha, 0f, k));
            yield return null;
        }

        SetMasksX(leftStartX, rightStartX);
        SetBlackAlpha(0f);
    }


    void SetMasksX(float leftX, float rightX)
    {
        var pL = maskLeft.anchoredPosition; pL.x = leftX; pL.y = 0f; maskLeft.anchoredPosition = pL;
        var pR = maskRight.anchoredPosition; pR.x = rightX; pR.y = 0f; maskRight.anchoredPosition = pR;
    }

    void SetMaskRotation(float z)
    {
        maskLeft.localRotation = Quaternion.Euler(0, 0, z);
        maskRight.localRotation = Quaternion.Euler(0, 0, -z);
    }

    void SetBlackAlpha(float a)
    {
        if (!black) return;
        var c = black.color;
        c.a = a;
        black.color = c;
    }

    float Ease01(float x)
    {
        x = Mathf.Clamp01(x);
        return x * x * (3f - 2f * x); // smoothstep
    }
}
