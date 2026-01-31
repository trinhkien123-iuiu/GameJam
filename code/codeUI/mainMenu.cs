using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public CurtainMaskTransition transitionPrefab;
    public void playGameBtn()
    {
        var t = Instantiate(transitionPrefab);
        t.StartToScene("SampleScene");

    }
    public void instructBtn()
    {

    }

    public void plotBtn()
    {

    }

    public void exitBtn()
    {

    }
}
