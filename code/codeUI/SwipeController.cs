using UnityEngine;

public class StoryPager : MonoBehaviour
{
    [Header("Pages (con của Pages)")]
    public GameObject[] pages;

    int currentPage = 0;

    void Start()
    {
        ShowPage(currentPage);
    }

    void ShowPage(int index)
    {
        for (int i = 0; i < pages.Length; i++)
            pages[i].SetActive(i == index);
    }

    public void Next()
    {
        if (currentPage >= pages.Length - 1) return;
        currentPage++;
        ShowPage(currentPage);
    }

    public void Prev()
    {
        if (currentPage <= 0) return;
        currentPage--;
        ShowPage(currentPage);
    }
}
