using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;

    }
    public GameObject gatePanel;
    public GameObject gameOverPanel;
    public GameObject deathPanel;
    public Image ItemImage;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Content;
    public GameObject ItemPanel;
    public TextMeshProUGUI pointText;
    public GameObject pointBar;
    public int point;


}
