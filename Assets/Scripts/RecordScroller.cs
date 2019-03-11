using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordScroller : MonoBehaviour
{
    [SerializeField] private GameObject [] m_levelList;
    private int m_currentLevel = 0;


    public void RightScroll()
    {
        m_levelList[m_currentLevel].SetActive(false);
        if (m_currentLevel == m_levelList.Length-1)
        {
            m_currentLevel = 0;
        }
        else
        {
            m_currentLevel += 1;
        }
        m_levelList[m_currentLevel].SetActive(true);
        
    }

    public void LeftScroll()
    {
        m_levelList[m_currentLevel].SetActive(false);
        if (m_currentLevel == 0)
        {
            m_currentLevel = m_levelList.Length-1;
        }
        else
        {
            m_currentLevel -= 1;
        }
        m_levelList[m_currentLevel ].SetActive(true);
    }
}
