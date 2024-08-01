using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void playAgain()
    {
        SceneManager.LoadScene(3);
        StartCoroutine(wait());
        Time.timeScale = 1.0f;
       
    }
    public void mainMenu()
    {

        SceneManager.LoadScene(0);
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);

    }
}
