using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public DataManager dataManager;
    [SerializeField] private float moveSpeed;
    Vector2 movement;
    Animator anim;
    bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("isAttack");
        }
    }
    void FixedUpdate()
    {
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
        else if(movement.x > 0 && !facingRight)
        {
            flip();
            facingRight = !facingRight;
        }

        
    }
    void flip()
    {
        transform.Rotate(0, 180f, 0);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collectable")
        {

            Destroy(collision.gameObject);

        }
    }
    void TakeDamage()
    {
        anim.SetTrigger("isDamaged");
       
    }
    void DeadFunc()
    {
        if (dataManager.health <= 0)
        {
            Time.timeScale = 0;
            //dead ui gelecek
        }
    }


}