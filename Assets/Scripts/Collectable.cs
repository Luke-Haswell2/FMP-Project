using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public float Collect = 0f;
    public int sceneToGoTo;

    void Update()
    {
        if (Collect == 1) //Watermelon
        {

        }
        if (Collect == 2)
        {

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Collect == 1) //Watermelon load next scene
            {
                LoadSpecificScene(sceneToGoTo);
            }

            if (Collect == 2)
            {

            }
        }
    }
    void LoadSpecificScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
