﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int m_Health = 3;
    private bool m_justHit;
    private bool isDied = false;

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
        Debug.Log("Your health: " + m_Health);
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
