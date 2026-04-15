using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public float forwardSpeed = 5f;
    public float jumpForce = 9f;

    private Rigidbody rb;
    private bool isGrounded;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Forward movement
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Jump
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0f);
        }

        // Speed increase
        forwardSpeed += Time.deltaTime * 0.05f;
    }

    void LateUpdate()
    {
        PlayerState state = new PlayerState
        {
            position = transform.position,
            velocity = rb.linearVelocity,
            isJumping = !isGrounded,
            timeStamp = Time.time
        };

        SyncManager.Instance.SendState(state);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            UIManager.Instance.ShowGameOver();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}