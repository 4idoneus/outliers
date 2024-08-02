using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable {  get; set; }

    Rigidbody2D rb;
    public DataManager dataManager;
    [SerializeField] private float moveSpeed;
    Vector2 movement;
    Animator anim;
    bool facingRight = true;
    public Image health;
    private bool isAttack = false;


    //Ýpek Hitbox Edit
    public GameObject Hitbox;
    Collider2D hitboxCollider;

    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsTargetable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        HealthManager.instance.HealthCheck();
        health.fillAmount = (float)dataManager.health / dataManager.maxHealth;
        UIManager.instance.pointBar.SetActive(true);
        UIManager.instance.pointText.text = UIManager.instance.point.ToString();
        //Ýpek Hitbox Edit 
        hitboxCollider = Hitbox.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (DialogueUI.IsOpen) return;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1") && !isAttack)
        {
            anim.SetTrigger("isAttack");
            isAttack = true;
            StartCoroutine(attack());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
                Interactable?.Interact(this);
        }
    }
    void FixedUpdate()
    {
        if (isAttack)
        {
            return;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        if (movement.y != 0 || movement.x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (movement.x < 0 && facingRight)
        {
            flip();
            facingRight = !facingRight;
        }
        else if (movement.x > 0 && !facingRight)
        {
            flip();
            facingRight = !facingRight;
        }


    }
    void flip()
    {
        transform.Rotate(0, 180f, 0);
    }



    IEnumerator attack()
    {
        yield return new WaitForSeconds(1);
        isAttack = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bread"))
        {
            UIManager.instance.point += 10;
            UIManager.instance.pointText.text = UIManager.instance.point.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("wood"))
        {
            UIManager.instance.point += 20;
            UIManager.instance.pointText.text = UIManager.instance.point.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("egg"))
        {
            UIManager.instance.point += 30;
            UIManager.instance.pointText.text = UIManager.instance.point.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("steak"))
        {
            UIManager.instance.point += 40;
            UIManager.instance.pointText.text = UIManager.instance.point.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "items")
        {
            UIManager.instance.ItemPanel.SetActive(true);
            isAttack = true;
            Destroy(collision.gameObject);
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "RedPotion")
        {
            dataManager.health += 25;
            Destroy(collision.gameObject);
            if (dataManager.health >= 100)
            {
                dataManager.health = 100;
            }
            health.fillAmount = (float)dataManager.health / dataManager.maxHealth;
        }
        if (collision.gameObject.tag == "BluePotion")
        {
            dataManager.health += 50;
            Destroy(collision.gameObject);
            if (dataManager.health >= 100)
            {
                dataManager.health = 100;
            }
            health.fillAmount = (float)dataManager.health / dataManager.maxHealth;
        }

    }
    public void ItemPanelClose()
    {

        UIManager.instance.ItemPanel.SetActive(false);
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForEndOfFrame();
        isAttack = false;
        Time.timeScale = 1;
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        TakeDamage(damage);
    }

    public void OnHit(float damage)
    {
        TakeDamage(damage);
    }

    public void OnObjectDestroyed()
    {
        throw new System.NotImplementedException();
    }
    private void TakeDamage(float damage)
    {
        HealthManager.instance.HealthCheck();
        anim.SetTrigger("isDamaged");
        dataManager.health -= (int)damage;
        health.fillAmount = (float)dataManager.health / dataManager.maxHealth;

        if (dataManager.health <= 0)
        {
            dataManager.health = 0;
            HealthManager.instance.HealthCheck();
            dataManager.extraHealth--;
            HealthManager.instance.DeadFunc();
            Time.timeScale = 0;
            UIManager.instance.deathPanel.SetActive(true);
            StartCoroutine(deathPanelWait());
        }
    }
    IEnumerator deathPanelWait()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        UIManager.instance.deathPanel.SetActive(false);
        Time.timeScale = 1;
        HealthManager.instance.HealthCheck();
        health.fillAmount = (float)dataManager.health / dataManager.maxHealth;

    }
}