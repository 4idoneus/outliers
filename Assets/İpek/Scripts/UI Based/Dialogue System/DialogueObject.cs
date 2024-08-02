using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType // Karakter türlerini temsil eden enum
{
    Character1,
    Character2,
    Character3,
    // Yeni karakter eklemek için burayý geniþletebilirsiniz
}

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue; // Diyalog metinleri
    [SerializeField] private Response[] responses; // Yanýtlar
    [SerializeField] private CharacterType[] speakers; // Konuþan karakterler

    public string[] Dialogue => dialogue;
    public Response[] Responses => responses;
    public CharacterType[] Speakers => speakers; // Eriþimci ekleyin

    public bool HasResponses => Responses != null && Responses.Length > 0;
}
