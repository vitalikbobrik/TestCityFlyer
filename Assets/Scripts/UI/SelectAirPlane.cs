using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectAirPlane : MonoBehaviour
{
    [SerializeField] private SOAirplane[] airPlanes;
    [SerializeField] private GameObject[] m_airPlanes;
    [SerializeField] private TextMeshProUGUI m_maxSpeed;
    [SerializeField] private TextMeshProUGUI m_nameAirPlane;
    public static int m_currentIndex = 0;

    private void Start()
    {
        m_airPlanes[m_currentIndex].SetActive(true);
        m_nameAirPlane.text = "Name: " + airPlanes[m_currentIndex].airPlaneName;
        m_maxSpeed.text = "Max Speed: " + airPlanes[m_currentIndex].MaxSpeed;
    }


    public void MoveRight()
    {
        m_airPlanes[m_currentIndex].SetActive(false);
        m_currentIndex += 1;
        if (m_currentIndex == airPlanes.Length)
        {
            m_currentIndex = 0;
        }
        m_airPlanes[m_currentIndex].SetActive(true);
        m_nameAirPlane.text = "Name: " + airPlanes[m_currentIndex].airPlaneName;
        m_maxSpeed.text = "Max Speed: " + airPlanes[m_currentIndex].MaxSpeed;
    }

    public void MoveLeft()
    {
        m_airPlanes[m_currentIndex].SetActive(false);
        m_currentIndex -= 1;
        if (m_currentIndex < 0)
        {
            m_currentIndex = airPlanes.Length - 1;
        }
        m_airPlanes[m_currentIndex].SetActive(true);
        m_nameAirPlane.text = "Name: " + airPlanes[m_currentIndex].airPlaneName;
        m_maxSpeed.text = "Max Speed: " + airPlanes[m_currentIndex].MaxSpeed;
    }
}
