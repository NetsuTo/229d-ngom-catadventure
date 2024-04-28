using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private Uiscore Uiscore;
    public void onClickPlay()
    {
        SceneManager.LoadScene("Main");
        Uiscore.Killc = 0;
    }

    public void onClickCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void onClickMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void onClickRestart()
    {
        SceneManager.LoadScene("Restart");
    }
    public void onClickExit()
    {
        Application.Quit();
    }
}
