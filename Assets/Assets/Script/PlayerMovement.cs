using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //References;
    Rigidbody rb;
    public Transform orientation;
    public float moveSpeed;
    public float jumpForce;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //JUMP
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);

        //SPEED LIMIT
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitVelocity = flatVelocity.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitVelocity.x, rb.linearVelocity.y, limitVelocity.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Ground")
        isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {   
        if(other.tag=="Ground")
        isGrounded = false;
    }
}
