using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Gerekli puan e�i�i
    public int requiredPoints = 100; // Gerekli puan miktar�n� buradan ayarlay�n.

    // Sahne ad� veya indeksi
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sadece "Player" tag'ine sahip objeler tetikleyebilir.
        if (other.CompareTag("Player"))
        {
            // Puan e�i�i kontrol�
            if (UIManager.instance.point >= requiredPoints)
            {
                // Bir sonraki sahneye ge�i� yap
                LoadNextScene();
            }
            else
            {
                UIManager.instance.gatePanel.SetActive(true);
                StartCoroutine(wait());

            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        UIManager.instance.gatePanel.SetActive(false);

    }

    private void LoadNextScene()
    {
        // Sahne de�i�ikli�ini ger�ekle�tir
        SceneManager.LoadScene(nextSceneName);
    }
}