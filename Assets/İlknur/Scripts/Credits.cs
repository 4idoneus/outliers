using System.Collections;
using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] credits;
    public float changeTime = 3.0f;
    private int currentLineIndex;

    private void Start()
    {
        StartCoroutine(ChangeCredits());
    }

    private IEnumerator ChangeCredits()
    {
        while (currentLineIndex < credits.Length)
        {
            text.text = credits[currentLineIndex];
            currentLineIndex++;
            yield return new WaitForSeconds(changeTime);
        }

        // Krediler bittiðinde oyunu kapat
        ExitGame();
    }

    private void ExitGame()
    {
        // Oyun kapanýþ kodu
        Application.Quit();

        // Editörde çalýþýrken oyunun kapanýþýný simüle et
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}