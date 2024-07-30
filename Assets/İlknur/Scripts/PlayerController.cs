using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        TakeDamage();
        //Ýpek Hitbox Edit 
        hitboxCollider = Hitbox.GetComponent<Collider2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1") && !isAttack)
        {
            anim.SetTrigger("isAttack");
            isAttack = true;
            StartCoroutine(attack());


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
    void TakeDamage()
    {
        HealthManager.instance.HealthCheck();
        anim.SetTrigger("isDamaged");
        dataManager.health -= dataManager.enemyDamage;
        health.fillAmount = (float)dataManager.health / dataManager.maxHealth;

        if (dataManager.health <= 0)
        {
            dataManager.health = 0;
            HealthManager.instance.HealthCheck();
            dataManager.extraHealth--;
            HealthManager.instance.DeadFunc();
            UIManager.instance.deathPanel.SetActive(true);
        }

    }
    IEnumerator attack()
    {
        yield return new WaitForSeconds(1);
        isAttack = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "items")
        {
            UIManager.instance.ItemPanel.SetActive(true);
            isAttack = true;
            Destroy(collision.gameObject);
            Time.timeScale = 0;
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


}