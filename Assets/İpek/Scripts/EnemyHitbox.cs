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