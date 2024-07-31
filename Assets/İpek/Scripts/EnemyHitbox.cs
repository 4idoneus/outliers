/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour 
{
    public float Damage = 1f;
    public float knockbackForce = 30f;
    public Collider2D hitboxCollider;
    void Start()
    {
        
        if (hitboxCollider == null)
        {
            Debug.LogWarning("Collider not set. ");
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Calculate Direction between player and enemy
            Vector3 parentPosition = transform.parent.position;
            Vector2 direction = (collider.gameObject.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            //Old method for the down below code : collider.SendMessage("OnHit", swordDamage, knockback);
            damageable.OnHit(Damage, knockback);
        }
        else
        {
            Debug.LogWarning("Collider does not implement IDamageable");
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        coll.collider.SendMessage("OnHit", Damage);
    }

}*/
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    [Header("Hitbox Properties")]
    public float Damage = 10f;
    public float KnockbackForce = 30f;
    public Collider2D HitboxCollider;

    private void Start()
    {
        if (HitboxCollider == null)
        {
            Debug.LogWarning("HitboxCollider not set. Please assign a Collider2D to the Hitbox.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Vector2 direction = (collider.transform.position - transform.position).normalized;
            Vector2 knockback = direction * KnockbackForce;

            damageable.OnHit(Damage, knockback);
        }
        else
        {
            Debug.LogWarning("Collider does not implement IDamageable.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Vector2 direction = (collision.collider.transform.position - transform.position).normalized;
            Vector2 knockback = direction * KnockbackForce;

            damageable.OnHit(Damage, knockback);
        }
    }
}