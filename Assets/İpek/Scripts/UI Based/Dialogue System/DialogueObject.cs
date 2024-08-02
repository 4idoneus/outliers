using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType // Karakter t�rlerini temsil eden enum
{
    Character1,
    Character2,
    Character3,
    // Yeni karakter eklemek i�in buray� geni�letebilirsiniz
}

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue; // Diyalog metinleri
    [SerializeField] private Response[] responses; // Yan�tlar
    [SerializeField] private CharacterType[] speakers; // Konu�an karakterler

    public string[] Dialogue => dialogue;
    public Response[] Responses => responses;
    public CharacterType[] Speakers => speakers; // Eri�imci ekleyin

    public bool HasResponses => Responses != null && Responses.Length > 0;
}
