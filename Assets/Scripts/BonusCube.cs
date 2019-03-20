using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCube : MonoBehaviour
{
    private Rigidbody m_airPlaneRb;


    private void Start()
    {
        m_airPlaneRb = GameObject.FindGameObjectWithTag("AirPlane").GetComponent<Rigidbody>();
        
    }
    private void OnTriggerEnter()
    {
        CityBuilder.Instance().m_AllCubes.Remove(gameObject);
        gameObject.SetActive(false);

    }


}
