using UnityEngine;

public interface IDamageable
{
    float Health { get; set; }
    bool IsTargetable { get; set; }

    // OnHit with both damage and knockback
    void OnHit(float damage, Vector2 knockback);

    // OnHit with only damage (default knockback)
    void OnHit(float damage);

    void OnObjectDestroyed();
}

