using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool touchingPlatform;
    private Animator anim;
    bool isJumping;
    bool ismoving;
    bool SoundActive;
    public AudioSource Grass;
    public AudioSource Soil;
    public AudioSource Rock;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isJumping = false;
        ismoving = false;
        SoundActive = true;
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
            ismoving = true;
        }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = false;
            ismoving = true;
        }
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = true;
            ismoving = true;
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = true;
            ismoving = true;
        }
        if (Input.GetKeyDown("space") && touchingPlatform)
        {
            rb.velocity = new Vector2(0, 8);
            isJumping = true;
        }
        if (isJumping == true)
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
        if (rb.velocity.x == 0)
        {
            ismoving = false;
        }
        if (ismoving == false)
        {
            Grass.enabled = false;
            Soil.enabled = false;
            Rock.enabled = false;
        }
        if (SoundActive == false)
        {
            ismoving = false;
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
        }
        if (collision.gameObject.tag == "Soil")
        {
            touchingPlatform = true;
        }
        if (collision.gameObject.tag == "Rock")
        {
            touchingPlatform = true;
        }
        if (collision.gameObject.tag == "Grass" && ismoving == true && isJumping == false)
        {
            Grass.enabled = true;
            Soil.enabled = false;
            Rock.enabled = false;
        }
        if (collision.gameObject.tag == "Soil" && ismoving == true && isJumping == false)
        {
            Grass.enabled = false;
            Soil.enabled = true;
            Rock.enabled = false;
        }
        if (collision.gameObject.tag == "Rock" && ismoving == true && isJumping == false)
        {
            Grass.enabled = false;
            Soil.enabled = false;
            Rock.enabled = true;
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fix")
        {
            SoundActive = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Fix")
        {
            SoundActive = true;
        }
    }
}
