using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Cutscene_One");
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void optionsMenu()
    {
        SceneManager.LoadScene("Options_Menu");
    }
}
