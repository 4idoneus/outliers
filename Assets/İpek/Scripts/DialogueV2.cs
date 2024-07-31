using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueV2 : MonoBehaviour
{

    public TextMeshProUGUI textComponent;  // TextMeshPro bile�eni
    public string[] sentences;  // C�mlelerin tutuldu�u dizi
    public float textSpeed;  // Harf yaz�lma h�z�

    private int index;  // Mevcut c�mlenin indeksi
    private bool isTyping;  // �u anda yaz�m i�lemi yap�l�p yap�lmad���n� kontrol eden de�i�ken
    private string currentText = "";  // �u ana kadar yaz�lm�� metni depolar

    void Start()
    {
        textComponent.text = string.Empty;  // Ba�lang��ta metin bo�
        StartCoroutine(TypeSentence());  // �lk c�mle yaz�lmaya ba�lan�r
    }

    void Update()
    {
        // Sol t�klama veya Space tu�u kontrol�
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopAllCoroutines(); // Yazma i�lemini durdur
                textComponent.text = currentText + sentences[index]; // C�mlenin geri kalan�n� an�nda g�ster
                isTyping = false; // Yaz�m i�lemi tamamland� olarak i�aretle

                // Yaz�lan c�mleyi currentText'e ekle
                currentText += sentences[index] + "\n\n"; // C�mleyi alt sat�ra ekle
            }
            else
            {
                NextSentence();  // Bir sonraki c�mleye ge�
            }
        }
    }

    IEnumerator TypeSentence()
    {
        isTyping = true;  // Yaz�m i�lemi ba�lad�

        // Mevcut metni temizle ve �nceki metinle g�ncelle
        textComponent.text = currentText;

        // C�mleleri s�rayla yaz
        foreach (char c in sentences[index].ToCharArray())
        {
            textComponent.text += c;  // Mevcut metni g�ncelle
            yield return new WaitForSeconds(textSpeed);  // Harf yaz�lma h�z� kadar bekle
        }

        isTyping = false;  // Yaz�m i�lemi tamamland�

        // C�mlenin yaz�m�ndan sonra currentText'i g�ncelle
        currentText += sentences[index] + "\n\n"; // Mevcut c�mleleri tampon metne ekle
    }

    void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;  // Bir sonraki c�mle
            StartCoroutine(TypeSentence());  // Yeni c�mleyi yazmaya ba�la
        }
        else
        {
            Invoke("GoToNextScene", 0.2f);  // T�m c�mleler tamamland���nda sahneyi de�i�tir
        }
    }

    void GoToNextScene()
    {
        // "NextSceneName" yerine ge�ilecek sahnenin ismini girin
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Credits() { SceneManager.LoadScene("Credits"); }
        
    }
