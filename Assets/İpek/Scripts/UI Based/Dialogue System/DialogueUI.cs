using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;

    [SerializeField] private GameObject[] characterGameObjects; // Karakter GameObject dizisi

    public bool IsOpen { get; private set; }

    private TypewriterEffect TypewriterEffect;
    private ResponseHandler ResponseHandler;

    private void Start()
    {
        TypewriterEffect = GetComponent<TypewriterEffect>();
        ResponseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        ResponseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            CharacterType speaker = dialogueObject.Speakers[i]; // Konu�an karakteri al

            UpdateCharacterGameObject(speaker); // GameObject'i g�ncelle

            yield return RunTypingEffect(dialogue);

            textLabel.text = dialogue;

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObject.HasResponses)
        {
            ResponseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    private void UpdateCharacterGameObject(CharacterType speaker)
    {
        // T�m karakter GameObject'lerini devre d��� b�rak�n
        foreach (var characterObject in characterGameObjects)
        {
            characterObject.SetActive(false);
        }

        // Konu�an karakterin GameObject'ini etkinle�tir
        switch (speaker)
        {
            case CharacterType.Character1:
                characterGameObjects[0].SetActive(true);
                break;
            case CharacterType.Character2:
                characterGameObjects[1].SetActive(true);
                break;
            default:
                break;
        }
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        TypewriterEffect.Run(dialogue, textLabel);

        while (TypewriterEffect.IsRuning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                TypewriterEffect.Stop();
            }
        }
    }

    public void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;

        // T�m karakter GameObject'lerini devre d��� b�rak
        foreach (var characterObject in characterGameObjects)
        {
            characterObject.SetActive(false);
        }
    }
}

