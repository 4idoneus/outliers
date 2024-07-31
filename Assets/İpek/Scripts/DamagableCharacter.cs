/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableCharacter : MonoBehaviour, IDamageable 
{
    public bool disableSimulation = false;
    public float _health = 50;
    bool isAlive = true;
    public bool _targetable = true;
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

    public float Health
    {
        set
        {
            if(value < _health)
            {
                animator.SetTrigger("Hurt");
            }
            _health = value;
            if(_health <= 0)
            {
                animator.SetBool("isAlive", false);
                Targetable = false;
            }
        }
        get
        {
            return _health;
        }
    }
    public bool Targetable { get {  return _targetable; } 
    set
        {
            _targetable = value;

            if( disableSimulation)
            {
                rb.simulated = false;
            }
            physicsCollider.enabled = true;
        }
    }
    public void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", true);
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = rb.GetComponent<Collider2D>();
    }
    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;

        rb.AddForce(knockback);
        Debug.Log("Force" + knockback);
    }
    public void OnHit(float damage)
    {
        Health -= damage;
    }
    public void OnObjectDestroyed() 
    {
        Destroy(gameObject);
    }

}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableCharacter : MonoBehaviour, IDamageable
{
    [Header("Character Stats")]
    public float Health = 50f;
    public float MoveSpeed = 5f;
    public float RotationSpeed = 360f;

    [Header("Character Flags")]
    public bool IsTargetable = true;
    public bool DisableSimulation = false;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Collider2D _physicsCollider;
    private bool _isAlive = true;

    float IDamageable.Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    bool IDamageable.IsTargetable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Start()
    {
        // Cache components
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _physicsCollider = GetComponent<Collider2D>();

        // Initialize character state
        _animator.SetBool("IsAlive", _isAlive);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        if (_isAlive)
        {
            Health -= damage;
            _animator.SetTrigger("Hurt");

            if (Health <= 0)
            {
                Die();
            }
            else
            {
                _rigidbody.AddForce(knockback, ForceMode2D.Impulse);
                Debug.Log($"Knockback applied: {knockback}");
            }
        }
    }

    public void OnHit(float damage)
    {
        OnHit(damage, Vector2.zero);
    }

    private void Die()
    {
        _isAlive = false;
        IsTargetable = false;
        _animator.SetBool("IsAlive", false);
        _rigidbody.velocity = Vector2.zero;
        _physicsCollider.enabled = false;

        // Additional death logic here (e.g., play sound, drop loot)
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }
}
