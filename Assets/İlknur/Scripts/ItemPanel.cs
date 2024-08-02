using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    public Sprite image;
    public string titles;
    public string contents;
   
    private void Start()
    {
        Items items =FindObjectOfType<Items>();
        ItemManager itemManager = items.getItems(titles);
        if (itemManager != null)
        {
            titles = itemManager.titles;
            contents = itemManager.texts;
            image = itemManager.images;
            UIManager.instance.Title.text = titles;
            UIManager.instance.Content.text = contents; 
            UIManager.instance.ItemImage.sprite= image;
        }
    }
    
    
}

