using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public DataManager dataManager;
    public CharacterController characterController; // Karakter controller referansý

    void Start()
    {
        // Ýlk yüklemede veri yönetimi
        //LoadData();
    }

    public void SaveData()
    {
        /*dataManager.maxHealth = PlayerController.maxHealth;
        dataManager.health = PlayerController.health;
        dataManager.damage = PlayerController.damage;
        dataManager.enemyDamage = PlayerController.enemyDamage;
        dataManager.extraHealth = PlayerController.extraHealth;
        dataManager.spawnPosition = PlayerController.transform.position;
    }

    public void LoadData()
    {
        if (dataManager != null && characterController != null)
        {
            PlayerController.maxHealth = dataManager.maxHealth;
            PlayerController.health = dataManager.health;
            PlayerController.damage = dataManager.damage;
            PlayerController.enemyDamage = dataManager.enemyDamage;
            PlayerController.extraHealth = dataManager.extraHealth;
            PlayerController.transform.position = dataManager.spawnPosition;
        }
    }*/
    }
}