using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCube : MonoBehaviour
{
    private Rigidbody m_airPlaneRb;
    private GameObject m_winScreen;


    private void Start()
    {
        m_airPlaneRb = GameObject.FindGameObjectWithTag("AirPlane").GetComponent<Rigidbody>();
        m_winScreen = GameObject.Find("WinScreen");
        if (m_winScreen != null)
        {
            m_winScreen.SetActive(false);
        }
    }
    private void OnTriggerEnter()
    {
        CityBuilder.Instance().m_AllCubes.Remove(gameObject);
        if(CityBuilder.Instance().m_AllCubes.Count == 0 && !GameState.IsWin)
        {
            GameState.IsWin = true;
            m_winScreen.SetActive(true);
            m_airPlaneRb.isKinematic = true;
        }
        if (PlayerPrefs.GetFloat("Level" + CurrentLevel.m_Level, Timer.m_currentTimer) > Timer.m_currentTimer)
        {
            PlayerPrefs.SetFloat("Level" + CurrentLevel.m_Level, Timer.m_currentTimer);
        }
        gameObject.SetActive(false);

    }


}
