using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            LoadMenu();
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
