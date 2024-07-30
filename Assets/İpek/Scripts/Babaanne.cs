using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babaanne : MonoBehaviour
{
    void OnHurt(float swordDamage)
    {
        Debug.Log("Babaanne hit." + swordDamage);
    }
}
