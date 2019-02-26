using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFinder : MonoBehaviour
{
    void Update()
    {
        Transform closest = GetClosestObject();
        if (closest != null)
        {
            transform.LookAt(closest);
        }
    }


    public Transform GetClosestObject()
    {
        float closest = 1000; 
        Transform closestObject = null;
        List <GameObject> m_cubes = CityBuilder.Instance().m_AllCubes;
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
