using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject m_pauseScreen;
    [SerializeField] private GameObject m_pauseButton;
    private GameObject m_airPlane;
    private void Start()
    {
        m_pauseScreen.SetActive(false);
        m_airPlane = GameObject.FindGameObjectWithTag("AirPlane");
    }

    public void OnPause()
    {
        m_pauseScreen.SetActive(true);
        GamePlay.IsPaused = true;
        m_airPlane.GetComponent<Rigidbody>().isKinematic = true;
        m_pauseButton.SetActive(false);
    }
    public void BackToGame()
    {
        m_pauseScreen.SetActive(false);
        GamePlay.IsPaused = false;
        m_airPlane.GetComponent<Rigidbody>().isKinematic = false;
        m_pauseButton.SetActive(true);

    }
}
