using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueV2 : MonoBehaviour
{

    public TextMeshProUGUI textComponent;  // TextMeshPro bileþeni
    public string[] sentences;  // Cümlelerin tutulduðu dizi
    public float textSpeed;  // Harf yazýlma hýzý

    private int index;  // Mevcut cümlenin indeksi
    private bool isTyping;  // Þu anda yazým iþlemi yapýlýp yapýlmadýðýný kontrol eden deðiþken
    private string currentText = "";  // Þu ana kadar yazýlmýþ metni depolar

    void Start()
    {
        textComponent.text = string.Empty;  // Baþlangýçta metin boþ
        StartCoroutine(TypeSentence());  // Ýlk cümle yazýlmaya baþlanýr
    }

    void Update()
    {
        // Sol týklama veya Space tuþu kontrolü
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopAllCoroutines(); // Yazma iþlemini durdur
                textComponent.text = currentText + sentences[index]; // Cümlenin geri kalanýný anýnda göster
                isTyping = false; // Yazým iþlemi tamamlandý olarak iþaretle

                // Yazýlan cümleyi currentText'e ekle
                currentText += sentences[index] + "\n\n"; // Cümleyi alt satýra ekle
            }
            else
            {
                NextSentence();  // Bir sonraki cümleye geç
            }
        }
    }

    IEnumerator TypeSentence()
    {
        isTyping = true;  // Yazým iþlemi baþladý

        // Mevcut metni temizle ve önceki metinle güncelle
        textComponent.text = currentText;

        // Cümleleri sýrayla yaz
        foreach (char c in sentences[index].ToCharArray())
        {
            textComponent.text += c;  // Mevcut metni güncelle
            yield return new WaitForSeconds(textSpeed);  // Harf yazýlma hýzý kadar bekle
        }

        isTyping = false;  // Yazým iþlemi tamamlandý

        // Cümlenin yazýmýndan sonra currentText'i güncelle
        currentText += sentences[index] + "\n\n"; // Mevcut cümleleri tampon metne ekle
    }

    void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;  // Bir sonraki cümle
            StartCoroutine(TypeSentence());  // Yeni cümleyi yazmaya baþla
        }
        else
        {
            Invoke("GoToNextScene", 0.2f);  // Tüm cümleler tamamlandýðýnda sahneyi deðiþtir
        }
    }

    void GoToNextScene()
    {
        // "NextSceneName" yerine geçilecek sahnenin ismini girin
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Credits() { SceneManager.LoadScene("Credits"); }
        
    }
