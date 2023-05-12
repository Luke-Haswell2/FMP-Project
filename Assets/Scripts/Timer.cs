using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;

    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("0.00");
    }
}
