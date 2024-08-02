using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    [Header("Character Stats")]
    public float Health = 100f;
    public float MoveSpeed = 5f;
    public float AttackDamage = 10f;
    public float AttackRange = 1f;
    public float AttackInterval = 1f;
    public float StopDistance = 1.5f;

    [Header("Character Flags")]
    public bool IsTargetable = true;
    public bool DisableSimulation = false;

    protected Animator _animator;
    protected Rigidbody2D _rigidbody;
    protected Collider2D _physicsCollider;
    protected bool _isAlive = true;
    protected bool _isMoving = false;
    protected float _nextAttackTime = 0.5f;

    [Header("Detection")]
    public DetectionZone DetectionZone;

    float IDamageable.Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    bool IDamageable.IsTargetable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _physicsCollider = GetComponent<Collider2D>();
        _animator.SetBool("isAlive", _isAlive);
    }

    private void FixedUpdate()
    {
        if (_isAlive)
        {
            HandleMovement();
            HandleAttack();
            FlipCharacter();
        }
    }

    private void HandleMovement()
    {
        if (DetectionZone.detectedObjects.Count > 0)
        {
            Vector2 targetPosition = DetectionZone.detectedObjects[0].transform.position;
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            float distanceToTarget = Vector2.Distance(transform.position, targetPosition);

            if (distanceToTarget > StopDistance)
            {
                _rigidbody.velocity = direction * MoveSpeed;
                _isMoving = true;
            }
            else
            {
                _rigidbody.velocity = Vector2.zero;
                _isMoving = false;
            }

            _animator.SetBool("isMoving", _isMoving);
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
            _isMoving = false;
            _animator.SetBool("isMoving", _isMoving);
        }
    }

    private void HandleAttack()
    {
        if (_isMoving == false && DetectionZone.detectedObjects.Count > 0)
        {
            GameObject target = DetectionZone.detectedObjects[0].gameObject;

            if (Time.time >= _nextAttackTime)
            {
                Attack(target);
                _nextAttackTime = Time.time + AttackInterval;
            }
        }
    }

    private void FlipCharacter()
    {
        if (_isMoving)
        {
            Vector2 targetPosition = DetectionZone.detectedObjects[0].transform.position;
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void Attack(GameObject target)
    {
        _animator.SetTrigger("Attack");

        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.OnHit(AttackDamage);
        }
    }

    public virtual void OnHit(float damage, Vector2 knockback)
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

    public virtual void OnHit(float damage)
    {
        Vector2 defaultKnockback = Vector2.zero;
        OnHit(damage, defaultKnockback);
    }

    private void Die()
    {
        _isAlive = false;
        IsTargetable = false;
        _animator.SetBool("isAlive", false);
        _rigidbody.velocity = Vector2.zero;
        _physicsCollider.enabled = false;
    }

    public void OnObjectDestroyed()
    {
        throw new System.NotImplementedException();
    }
}
