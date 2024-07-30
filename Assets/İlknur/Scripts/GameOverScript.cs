using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void playAgain()
    {
        SceneManager.LoadScene(3);
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void mainMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
