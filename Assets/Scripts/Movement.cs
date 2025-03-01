using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float horizontalVelocity = 0f;

    [SerializeField]
    private float verticalVelocity = 0f;

    private float groundRadius = .1f;
    public Rigidbody2D rb;

    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vertical = new Vector2(0, verticalVelocity);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);

        groundCheck.transform.position = new Vector2(rb.position.x, rb.position.y - 0.5f);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(vertical, ForceMode2D.Impulse);
        }

    }

    void FixedUpdate()
    {
        Vector2 horizontal = new Vector2(Input.GetAxis("Horizontal") * horizontalVelocity, 0);

        if (isGrounded)
        {
            rb.AddForce(horizontal);
        }
    }
}
