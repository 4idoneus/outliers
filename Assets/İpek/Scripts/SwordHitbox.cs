using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float swordDamage = 1f;
    public Collider2D hitboxCollider;
    private void Start()
    {
        if (hitboxCollider == null)
        {
            Debug.LogWarning("Sword Collider not set. ");
        }

        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        coll.collider.SendMessage("OnHurt", swordDamage);
    }

}
