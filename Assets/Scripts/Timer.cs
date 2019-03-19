using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI m_timer;
    public static float m_currentTimer;

    void Start()
    {
        m_timer = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!GameState.IsPaused && !GameState.IsWin && !GameState.isDied)
        {
            m_currentTimer += Time.deltaTime;
            m_timer.text = "Your time: " + (Mathf.Round(m_currentTimer*100))/100;
        }
    }
    
}
