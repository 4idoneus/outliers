using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public DataManager dataManager;
    public List<GameObject> extraHealths;

    public static HealthManager instance;
    private void Awake()
    {
        if (instance != null &&instance!=this)
        {
            Destroy(gameObject);
        }
        instance = this;

    }

    
    public void DeadFunc()
    {

        if (dataManager.extraHealth < 0 && dataManager.health <= 0)
        {
            Time.timeScale = 0;
            UIManager.instance.gameOverPanel.SetActive(true);
        }
        else
        {
            dataManager.health = dataManager.maxHealth;
        }
    }
   public void HealthCheck()
    {
        switch (dataManager.extraHealth)
        {
            case 0:
                extraHealths[0].SetActive(false);
                extraHealths[1].SetActive(false);
                extraHealths[2].SetActive(false);
                break;

            case 1:
                extraHealths[0].SetActive(true);
                extraHealths[1].SetActive(false);
                extraHealths[2].SetActive(false);
                break;
            case 2:
                extraHealths[0].SetActive(true);
                extraHealths[1].SetActive(true);
                extraHealths[2].SetActive(false);
                break;
            case 3:
                extraHealths[0].SetActive(true);
                extraHealths[1].SetActive(true);
                extraHealths[2].SetActive(true);
                break;
            default:
                UIManager.instance.gameOverPanel.SetActive(true);
                break;
        }
    }
}
