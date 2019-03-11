using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameObject m_healthCanvas;
    private GameObject m_loseScreen;
    private ParticleSystem m_fire;
    private Rigidbody m_rb;
    private Animation m_justHitAnim;
    public int m_Health = 3;
    private bool m_justHit;
    private bool isDied = false;

    private void Start()
    {
        m_healthCanvas = GameObject.Find("AirPlaneHealth");
        m_loseScreen = GameObject.Find("LoseScreen");
        m_loseScreen.SetActive(false);
        m_fire = GetComponentInChildren<ParticleSystem>(true);
        m_rb = GetComponent<Rigidbody>();
        m_justHitAnim = GetComponent<Animation>();
    }
    private void OnCollisionEnter()
    {
        if (!m_justHit && m_Health>0)
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        m_Health--;
        m_healthCanvas.transform.GetChild(m_Health).gameObject.SetActive(false);
        m_justHit = true;
        //m_justHitAnim.Play("JustHitAnim");
        if (m_Health <= 0 && !isDied)
        {
            m_loseScreen.SetActive(true);
            m_fire.Play();
            m_rb.isKinematic = true;
            isDied = true;
        }
        yield return new WaitForSeconds(3f);
        m_justHit = false;
        //m_justHitAnim.Stop();
    }

}
