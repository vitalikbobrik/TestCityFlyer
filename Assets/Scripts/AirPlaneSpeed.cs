using UnityEngine;
using TMPro;

public class AirPlaneSpeed : MonoBehaviour
{
    private TextMeshProUGUI m_currentSpeed;
    private GameObject m_airPlane;
    private Rigidbody m_rb;

    private void Start()
    {
        m_airPlane = GameObject.FindGameObjectWithTag("AirPlane");
        m_rb = m_airPlane.GetComponent<Rigidbody>();
        m_currentSpeed = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        m_currentSpeed.text = "Speed: " + (int)m_rb.velocity.magnitude;
    }
}
