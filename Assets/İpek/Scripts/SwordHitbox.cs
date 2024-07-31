/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float swordDamage = 1f;
    public float knockbackForce = 30f;
    public Collider2D hitboxCollider;
    void Start()
    {
        if (hitboxCollider == null)
        {
            Debug.LogWarning("Sword Collider not set. ");
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();
        
        if (damageable != null)
        {
            //Calculate Direction between player and enemy
            Vector3 parentPosition = transform.parent.position;
            Vector2 direction = (collider.gameObject.transform.position - parentPosition ).normalized;
            Vector2 knockback = direction * knockbackForce;
            
            //Old method for the down below code : collider.SendMessage("OnHit", swordDamage, knockback);
            damageable.OnHit(swordDamage, knockback);
        }
        else
        {
            Debug.LogWarning("Collider does not implement IDamageable");
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        coll.collider.SendMessage("OnHit", swordDamage);
    }

}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    [Header("Sword Properties")]
    public float SwordDamage = 1f;
    public float KnockbackForce = 30f;
    public Collider2D HitboxCollider;

    private void Start()
    {
        if (HitboxCollider == null)
        {
            Debug.LogWarning("Sword Collider not set. Please assign a Collider2D to the Hitbox.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            // Calculate direction between player and enemy
            Vector3 parentPosition = transform.parent.position;
            Vector2 direction = (collider.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * KnockbackForce;

            // Apply damage and knockback
            damageable.OnHit(SwordDamage, knockback);
        }
        else
        {
            Debug.LogWarning("Collider does not implement IDamageable.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            Debug.LogWarning("Collider does not implement IDamageable.");
        
    }
}
