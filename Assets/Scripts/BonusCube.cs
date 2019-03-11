using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCube : MonoBehaviour
{
    [SerializeField] private GameObject m_winScreen;

    private void Start()
    {
        m_winScreen = GameObject.Find("WinScreen");
        m_winScreen.SetActive(false);
    }
    private void OnTriggerEnter()
    {
        gameObject.SetActive(false);
        CityBuilder.Instance().m_AllCubes.Remove(gameObject);
        if (CityBuilder.Instance().m_AllCubes.Count == 0 && GamePlay.IsWin == false)
        {
            Debug.Log("You Win!");
            GamePlay.IsWin = true;
            m_winScreen.SetActive(true);
        }
    }
}
