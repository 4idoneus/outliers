using System.Collections;
using System.Collections.Generic;
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

    IEnumerator ChangeCredits()
    {
        while(true)
        {
            text.text = credits[currentLineIndex];
            currentLineIndex=currentLineIndex+1% credits.Length;
            yield return new WaitForSeconds(changeTime);
        }
    }

}
