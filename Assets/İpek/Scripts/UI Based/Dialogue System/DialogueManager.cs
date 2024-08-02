using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject; // Diyalog içeriði
    [SerializeField] private DialogueUI dialogueUI; // Diyalog UI'sý

    public void StartDialogue()
    {
        if (dialogueObject != null && dialogueUI != null)
        {
            dialogueUI.ShowDialogue(dialogueObject);
        }
    }
}
