using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotate : MonoBehaviour
{
    [SerializeField] private float m_rotationSpeed = 20F;
 
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, m_rotationSpeed * Time.deltaTime);
    }
}
