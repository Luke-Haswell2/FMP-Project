using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private Transform currentPoint;
    public float speed;
    private Animator anim;
    private float timer;
    public BossProjectile ProjectilePrefab;
    public Transform LaunchOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentPoint = pointB.transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("Throw", false);
        timer += Time.deltaTime;

        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
            anim.SetBool("Walk", true);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            anim.SetBool("Walk", true);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
            sr.flipX = true;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
            sr.flipX = false;
        }
        if (transform.position.x < pointC.transform.position.x && timer > 3)
        {
            anim.SetBool("Throw", true);
            timer = 0;
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }
}
