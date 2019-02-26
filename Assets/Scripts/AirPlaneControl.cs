using UnityEngine;
using System.Collections;

public class AirPlaneControl : MonoBehaviour
{

    [SerializeField] private float rotationRate = 100;

    [SerializeField] private float moveRate = 2f;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float maxSpeed = 30f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        StartCoroutine(UnSetKinematic());
    }

    IEnumerator UnSetKinematic()
    {
        yield return new WaitForSeconds(3f);
        rb.isKinematic = false;
    }   

    private void FixedUpdate()
    {
        float upAxis = Input.GetAxis("Vertical");
        float turnAxis = Input.GetAxis("Horizontal");
        MoveTowards(moveSpeed);
        ApplyInput(upAxis, turnAxis);
        CheckBrakes();
    }

    private void CheckBrakes()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = rb.velocity * 0.97f;
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
        rb.AddForce(transform.up * input * moveRate, ForceMode.Impulse);
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }

    private void MoveTowards(float speed)
    {
        if (Input.GetKey(KeyCode.Space)) return;
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        rb.AddForce(transform.forward * speed, ForceMode.Force);
    }
}
