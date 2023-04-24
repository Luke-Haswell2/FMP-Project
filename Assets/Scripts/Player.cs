using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool touchingPlatform;
    private Animator anim;
    bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isJumping = false;
    }

    void Update()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Throw", false);

        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = false;
        }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = false;
        }
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = true;
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = true;
        }
        if (Input.GetKeyDown("space") && touchingPlatform)
        {
            rb.velocity = new Vector2(0, 8);
            isJumping = true;
        }
        if ((isJumping == true))
        {
            anim.SetBool("Jump", true);
            if ((touchingPlatform == true) && rb.velocity.y < 1)
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyDown("b"))
        {
            anim.SetBool("Throw", true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            LoadMenu();
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            touchingPlatform = true;
            print("Grass");
        }
        if (collision.gameObject.tag == "Soil")
        {
            touchingPlatform = true;
            print("Soil");
        }
        if (collision.gameObject.tag == "Rock")
        {
            touchingPlatform = true;
            print("Rock");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            touchingPlatform = false;
        }
        if (collision.gameObject.tag == "Soil")
        {
            touchingPlatform = false;
        }
        if (collision.gameObject.tag == "Rock")
        {
            touchingPlatform = false;
        }
    }
}
