using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Gerekli puan eþiði
    public int requiredPoints = 100; // Burada gerekli puan miktarýný ayarlayabilirsiniz.

    // Sahne adý veya indeksi
    public string nextSceneName;

    private void Update()
    {
        // Puan eþiði kontrolü
        if (UIManager.instance.point >= requiredPoints)
        {
            // Bir sonraki sahneye geçiþ yap
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Sahne deðiþikliðini gerçekleþtir
        SceneManager.LoadScene(nextSceneName);
    }
}
