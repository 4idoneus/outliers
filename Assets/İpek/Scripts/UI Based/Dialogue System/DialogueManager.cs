using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject; // Diyalog i�eri�i
    [SerializeField] private DialogueUI dialogueUI; // Diyalog UI's�

    public void StartDialogue()
    {
        if (dialogueObject != null && dialogueUI != null)
        {
            dialogueUI.ShowDialogue(dialogueObject);
        }
    }
}
