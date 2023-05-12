using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool touchingPlatform;
    Animator anim;

    bool isJumping;
    bool ismoving;
    bool SoundActive;
    bool left;
    bool rightOn;
    bool leftOn;

    public AudioSource Grass;
    public AudioSource Soil;
    public AudioSource Rock;

    public Projectile ProjectilePrefab;
    public Transform LaunchOffset;
    public ProjectileL ProjectilePrefabL;
    public Transform LaunchOffsetL;

    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Jump.performed += ctx => Jump();
        controls.Gameplay.Throw.performed += ctx => Throw();
        controls.Gameplay.Menu.performed += ctx => LoadMenu();
        controls.Gameplay.Right.performed += ctx => Right();
        controls.Gameplay.Left.performed += ctx => Left();

        controls.Gameplay.Right.canceled += ctx => Right2();
        controls.Gameplay.Left.canceled += ctx => Left2();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isJumping = false;
        ismoving = false;
        SoundActive = true;
        left = false;
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
            left = false;
        }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = false;
            ismoving = true;
            left = false;
        }
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = true;
            ismoving = true;
            left = true;
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = true;
            ismoving = true;
            left = true;
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
            if (left == true)
            {
                Instantiate(ProjectilePrefabL, LaunchOffsetL.position, transform.rotation);
            }
            if (left == false)
            {
                Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            } 
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
        if (rightOn == true)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = false;
            ismoving = true;
            left = false;
        }
        if (leftOn == true)
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = true;
            ismoving = true;
            left = true;
        }
    }

    void Jump()
    {
        if (touchingPlatform == true)
        {
            rb.velocity = new Vector2(0, 8);
            isJumping = true;
        }
    }
    void Throw()
    {
        anim.SetBool("Throw", true);
        if (left == true)
        {
            Instantiate(ProjectilePrefabL, LaunchOffsetL.position, transform.rotation);
        }
        if (left == false)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }
    void Right()
    {
        rightOn = true;
    }
    void Right2()
    {
        rightOn = false;
    }
    void Left()
    {
        leftOn = true;
    }
    void Left2()
    {
        leftOn = false;
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
        if (collision.gameObject.tag == "EProjectile")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.tag == "Boss")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
