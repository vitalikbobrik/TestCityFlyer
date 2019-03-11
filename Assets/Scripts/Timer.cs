using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI m_timer;
    private float m_currentTimer;


    void Start()
    {
        m_timer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GamePlay.IsPaused)
        {
            m_currentTimer += Time.deltaTime;
            m_timer.text = "Your time: " + (Mathf.Round(m_currentTimer*100))/100;
        }
    }
}
