using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class EndStory : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("Final Level");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
