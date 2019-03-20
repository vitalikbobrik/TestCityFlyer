using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameState : MonoBehaviour
{
    public static bool IsWin = false;
    public static bool IsPaused = false;
    public static bool isDied = false;

    [SerializeField] private GameObject m_winScreen;
    private Rigidbody m_airPlaneRb;

    private void Start()
    {
        GameObject airPlane = GameObject.FindGameObjectWithTag("AirPlane");
        if (airPlane != null)
        {
            m_airPlaneRb = airPlane.GetComponent<Rigidbody>();
        }
        if (m_winScreen != null)
        {
            m_winScreen.SetActive(false);
        }
    }

    private void Update()
    {
        CheckWin();
    }

    
    private void CheckWin()
    {
        if (CityBuilder.Instance().m_AllCubes.Count == 0 && !IsWin)
        {
            IsWin = true;
            m_winScreen.SetActive(true);
            m_airPlaneRb.isKinematic = true;

            if ((PlayerPrefs.GetFloat("Level" + CurrentLevel.m_Level) > Timer.m_currentTimer) ||
                (PlayerPrefs.GetFloat("Level" + CurrentLevel.m_Level) < 0.1f))
            {
                PlayerPrefs.SetFloat("Level" + CurrentLevel.m_Level, Timer.m_currentTimer);
            }
        }
    }

    
}
