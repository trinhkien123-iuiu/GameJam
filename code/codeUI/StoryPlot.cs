using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class StoryPlot : MonoBehaviour
{

    [Header("UI")]
    public Image storyImage;
    public TMP_Text storyText;
    public GameObject panel;

    [Header("Content")]
    public Sprite[] images;
    [TextArea(3, 5)]
    public string[] texts;

    [Header("Typewriter")]
    public float charDelay = 0.03f;

    int index = 0;
    Coroutine typingCoroutine;
    bool isTyping = false;

    void OnEnable()
    {
        index = 0;
        ShowSlide();
    }

    void ShowSlide()
    {
        storyImage.sprite = images[index];
        storyText.text = "";

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(texts[index]));
    }

    IEnumerator TypeText(string fullText)
    {
        isTyping = true;
        storyText.text = "";

        foreach (char c in fullText)
        {
            storyText.text += c;
            yield return new WaitForSeconds(charDelay);
        }

        isTyping = false;
    }

    public void Next()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            storyText.text = texts[index];
            isTyping = false;
            return;
        }

        index++;

        if (index >= images.Length)
        {
            Close();
            return;
        }

        ShowSlide();
    }

    public void Close()
    {
        panel.SetActive(false);
    }
}

