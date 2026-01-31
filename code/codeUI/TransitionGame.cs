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
    public float rotateDegrees = 180f;     // mỗi pha xoay bao nhiêu độ
    public float extraOffscreen = 250f;    // mask nằm ngoài màn thêm bao nhiêu

    [Header("Black")]
    public float blackMaxAlpha = 1f;

    // vị trí X cho 2 pha
    float leftClosedX, rightClosedX;
    float leftOpenX, rightOpenX;

    void Awake()
    {
        // Đảm bảo luôn vẽ trên cùng và không mất khi load scene
        DontDestroyOnLoad(gameObject);

        // Tính toán dựa trên kích thước màn hình UI
        float halfW = root.rect.width * 0.5f;

        // "Closed": 2 mask gặp nhau ở giữa (bạn chỉnh số này để che kín)
        // Gợi ý: closedX = 0 là gặp ngay tâm. Nếu bị hở giữa, dùng +/- nhỏ.
        leftClosedX = 0f;
        rightClosedX = 0f;

        // "Open": kéo ra ngoài màn hình
        leftOpenX = -halfW - extraOffscreen;
        rightOpenX = halfW + extraOffscreen;

        // set trạng thái ban đầu: mở (ẩn) + nền đen trong suốt
        SetBlackAlpha(0f);
        SetMasksX(leftOpenX, rightOpenX);
        SetMaskRotation(0f);
    }

    // Gọi từ menu
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

            float lx = Mathf.Lerp(leftOpenX, leftClosedX, k);
            float rx = Mathf.Lerp(rightOpenX, rightClosedX, k);
            SetMasksX(lx, rx);

            float rot = rotateDegrees * k;
            maskLeft.localRotation = Quaternion.Euler(0, 0, +rot);
            maskRight.localRotation = Quaternion.Euler(0, 0, -rot);

            SetBlackAlpha(Mathf.Lerp(0f, blackMaxAlpha, k));

            yield return null;
        }

        SetMasksX(leftClosedX, rightClosedX);
        SetBlackAlpha(blackMaxAlpha);
    }

    IEnumerator Open()
    {
        float t = 0f;
        while (t < openDuration)
        {
            t += Time.unscaledDeltaTime;
            float k = Ease01(t / openDuration);

            // mask từ closed -> open, nhưng “đi về phía đối diện” nếu bạn muốn kiểu swap
            // Nếu muốn "mỗi mask đi về phía đối diện":
            //  left: 0 -> +openRightX, right: 0 -> -openLeftX
            // Còn nếu muốn "mỗi mask quay về bên cũ": dùng 2 dòng Lerp dưới.

            // CÁCH A: mở về bên cũ (dễ hiểu)
            float lx = Mathf.Lerp(leftClosedX, leftOpenX, k);
            float rx = Mathf.Lerp(rightClosedX, rightOpenX, k);

            // CÁCH B: mở về phía đối diện (đổi bên) - bật nếu bạn thích
            // float lx = Mathf.Lerp(leftClosedX, rightOpenX, k);
            // float rx = Mathf.Lerp(rightClosedX, leftOpenX, k);

            SetMasksX(lx, rx);

            // xoay tiếp
            float rot = rotateDegrees * k;
            maskLeft.localRotation = Quaternion.Euler(0, 0, +rot);
            maskRight.localRotation = Quaternion.Euler(0, 0, -rot);

            // nền đen fade out
            SetBlackAlpha(Mathf.Lerp(blackMaxAlpha, 0f, k));

            yield return null;
        }

        SetMasksX(leftOpenX, rightOpenX);
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
