using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour
{
    public void GoToNextScene()
    {
        // "NextSceneName" yerine ge�ilecek sahnenin ismini girin
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
