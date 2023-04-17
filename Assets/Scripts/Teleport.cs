using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public int sceneToGoTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;
        LoadSpecificScene(sceneToGoTo);
    }

    void LoadSpecificScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
