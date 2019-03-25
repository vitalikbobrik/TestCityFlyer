using UnityEngine;
using System.Collections;
using System;

public class AirPlaneControl : MonoBehaviour
{
    [Header("Airplane Settings:")]
    [SerializeField] private float rotationRate = 100f;
    [SerializeField] private float upDownRate = 2f;
    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private float maxSpeed = 50f;

    private Rigidbody rb;
    private float upAxis;
    private float turnAxis;
    public static bool IsBraking;
    private Quaternion calibrate;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        StartCoroutine(UnSetKinematic());
    }

   

    IEnumerator UnSetKinematic()
    {
        GameState.IsPaused = true;
        yield return new WaitForSeconds(3f);
        GameState.IsPaused = false;
        rb.isKinematic = false;
    }   

    private void FixedUpdate()
    {
        
        if (Application.platform == RuntimePlatform.Android)
        {
            turnAxis = Input.acceleration.z;
            upAxis = Input.acceleration.y;
        }
        else
        {
            upAxis = Input.GetAxis("Vertical");
            turnAxis = Input.GetAxis("Horizontal");
        }
        MoveTowards(moveSpeed);
        ApplyInput(upAxis, turnAxis);
        CheckBrakes();
    }

    

    public void CheckBrakes()
    {
        if (Input.GetKey(KeyCode.Space) || IsBraking)
        {
            rb.velocity = rb.velocity * 0.95f;
        }

    }
    private void ApplyInput(float moveInput,
                            float turnInput)
    {
        MoveUpDown(moveInput);
        Turn(turnInput);
    }

    private void MoveUpDown(float input)
    {
        rb.AddForce(transform.up * input * upDownRate, ForceMode.Impulse);
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }

    private void MoveTowards(float speed)
    {
        if (Input.GetKey(KeyCode.Space) || IsBraking) return;
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        rb.AddForce(transform.forward * speed, ForceMode.Force);
    }
}
