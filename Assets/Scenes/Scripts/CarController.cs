using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");   // W / S
        float turn = Input.GetAxis("Horizontal"); // A / D

        // Gerak maju mundur
        Vector3 moveDirection = transform.forward * move * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        // Belok
        float turnAmount = turn * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}