using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions playerControls;
    private Rigidbody playerRb;
    public GameObject bulletPrefab;
    private float playerSpeed = 20.0f;
    private float jumpForce = 5.0f;
    private int rotation = 90;
    private int playerHealth = 3;
    [SerializeField] private bool onGround = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerControls = new InputSystem_Actions();
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        PlayerRotation();

        Jump();

        Attack();
    }

    private void Move()
    {
        Vector2 playerMove = playerControls.Player.Move.ReadValue<Vector2>();

        float horizontalInput = playerMove.y;
        float verticalInput = playerMove.x;

        transform.position += horizontalInput * playerSpeed * Time.deltaTime * Vector3.forward;
        transform.position += playerSpeed * Time.deltaTime * verticalInput * Vector3.right;

        if (playerControls.Player.Interact.triggered)
        {
            transform.Rotate(Vector3.up);
        }
    }

    private void PlayerRotation()
    {
        if (playerControls.Player.TurnLeft.triggered)
        {
            transform.Rotate(Vector3.up * -rotation);
        }

        if (playerControls.Player.TurnRight.triggered)
        {
            transform.Rotate(Vector3.up * rotation);
        }
    }

    private void Attack()
    {
        if (playerControls.Player.Attack.triggered)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
    private void Jump()
    {
        if (playerControls.Player.Jump.triggered && onGround == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    public void TakeDammage()
    {
        playerHealth--;
        if (playerHealth == 0)
        {
            Destroy(gameObject);
        }
    }

}
