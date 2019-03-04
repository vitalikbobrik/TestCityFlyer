using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameObject m_healthCanvas;
    public int m_Health = 3;
    private bool m_justHit;
    private bool isDied = false;

    private void Start()
    {
        m_healthCanvas = GameObject.Find("AirPlaneHealth");

    }
    private void OnCollisionEnter()
    {
        if (!m_justHit)
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        m_Health--;
        m_healthCanvas.transform.GetChild(m_Health).gameObject.SetActive(false);
        //Debug.Log("Your health: " + m_Health);
        m_justHit = true;
        yield return new WaitForSeconds(3f);
        m_justHit = false;
    }
    

    private void Update()
    {
        if(m_Health <= 0 && !isDied)
        {
            Debug.Log("You Lose!");
            isDied = true;
        }
    }
}
