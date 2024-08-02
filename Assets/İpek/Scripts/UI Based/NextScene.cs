using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Gerekli puan eþiði
    public int requiredPoints = 100; // Gerekli puan miktarýný buradan ayarlayýn.

    // Sahne adý veya indeksi
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sadece "Player" tag'ine sahip objeler tetikleyebilir.
        if (other.CompareTag("Player"))
        {
            // Puan eþiði kontrolü
            if (UIManager.instance.point >= requiredPoints)
            {
                // Bir sonraki sahneye geçiþ yap
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
        // Sahne deðiþikliðini gerçekleþtir
        SceneManager.LoadScene(nextSceneName);
    }
}