using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public CurtainMaskTransition transitionPrefab;
    public GameObject mainPanel;
    public GameObject instructionPanel;
    public GameObject plotPanel;

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainPanel.SetActive(true);
        instructionPanel.SetActive(false);
        plotPanel.SetActive(false);
    }

    public void playGameBtn()
    {
        var t = Instantiate(transitionPrefab);
        t.StartToScene("GamePlayDemo");
    }

    public void OpenInstruction()
    {
        mainPanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    // public void OpenPlot()
    // {
    
    // }

    public void CloseCurrentPopup()
    {
        ShowMainMenu();
    }
}
