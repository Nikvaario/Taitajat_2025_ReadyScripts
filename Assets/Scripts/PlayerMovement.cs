using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Moving Variables")]
    [SerializeField] private float speed = 3.0f; // How fast the player moves
    [HideInInspector] public float Direction = 0; // Direction of player movement

    [Header("Jump Variables")]
    [SerializeField] private float jumpForce; // How much force is put into the jump

    [Header("Groundcheck Variables")]
    public bool isGrounded = false; // Is player grounded
    public float castDistance = 0.51f; // How long is groundcheck raycast distance
    [SerializeField] private LayerMask groundLayer; // Layer to be detected for Groundcheck

    private Rigidbody2D rb; // Reference to Rigidbody2D component in object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateGroundcheck();
    }

    // Function called once per frame for moving the character
    void UpdateMovement()
    {
        transform.position += new Vector3(speed * Direction * Time.deltaTime, 0);
    }

    // Function called once per frame to detect ground
    void UpdateGroundcheck()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, castDistance, groundLayer))
        {
            isGrounded = true;
        }
        else { isGrounded = false; }
    }

    // Function called to jump
    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }
}
