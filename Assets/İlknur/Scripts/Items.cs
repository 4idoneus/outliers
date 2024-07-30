using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public ItemManager[] Manager;
   public ItemManager getItems(string itemName) {
        foreach (ItemManager item in Manager)
        {
            if (item.titles == itemName)
            {
                return item;
            }
        }
     return null;
    
    
   }
}
