using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] int maxPage = 1;
    int currentPage = 1;

    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;

    [SerializeField] float moveSpeed = 1600f;   // px/giây
    [SerializeField] float snapDistance = 0.5f; // chốt vị trí

    Vector3 targetPos;

    void Awake()
    {
        targetPos = levelPagesRect.localPosition;
    }

    void Update()
    {
        levelPagesRect.localPosition =
            Vector3.MoveTowards(levelPagesRect.localPosition, targetPos, moveSpeed * Time.deltaTime);

        if ((levelPagesRect.localPosition - targetPos).sqrMagnitude <= snapDistance * snapDistance)
            levelPagesRect.localPosition = targetPos;
    }

    public void Next()
    {
        if (currentPage >= maxPage) return;
        currentPage++;
        targetPos += pageStep;
    }

    public void Previous()
    {
        if (currentPage <= 1) return;
        currentPage--;
        targetPos -= pageStep;
    }
}
