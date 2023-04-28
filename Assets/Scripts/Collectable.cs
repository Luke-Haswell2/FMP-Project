using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float Collect = 0f;

    void Update()
    {
        if (Collect == 1) //Watermelon
        {

        }
        if (Collect == 2)
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Collect == 1) //Watermelon load next scene
            {

            }

            if (Collect == 2)
            {

            }
        }
    }
}
