using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Gerekli puan e�i�i
    public int requiredPoints = 100; // Burada gerekli puan miktar�n� ayarlayabilirsiniz.

    // Sahne ad� veya indeksi
    public string nextSceneName;

    private void Update()
    {
        // Puan e�i�i kontrol�
        if (UIManager.instance.point >= requiredPoints)
        {
            // Bir sonraki sahneye ge�i� yap
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Sahne de�i�ikli�ini ger�ekle�tir
        SceneManager.LoadScene(nextSceneName);
    }
}
