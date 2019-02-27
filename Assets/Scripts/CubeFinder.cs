using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFinder : MonoBehaviour
{
    private List<GameObject> m_cubes = new List<GameObject>();
    public bool m_IsWin = false;
    private Transform closest;

    void Update()
    {
        closest = GetClosestObject();

        if (m_cubes.Count == 0 && m_IsWin == false)
        {
            Debug.Log("You Win!");
            m_IsWin = true;
        }
        else
        {
            if (closest == null) return;
            transform.LookAt(closest);
        }


    }


    public Transform GetClosestObject()
    {
        float closest = 1000;
        Transform closestObject = null;
        m_cubes = CityBuilder.Instance().m_AllCubes;
        for (int i = 0; i < m_cubes.Count; i++)
        {
            if (m_cubes[i].activeSelf == false)
            {
                continue;
            }
            float dist = Vector3.Distance(m_cubes[i].transform.position, transform.position);
            if (dist < closest)
            {
                closest = dist;
                closestObject = m_cubes[i].transform;
            }
        }
        return closestObject;
    }
}
