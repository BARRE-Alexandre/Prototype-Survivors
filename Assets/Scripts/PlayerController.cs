using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions playerControls;
    private float playerSpeed = 20.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerControls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerMove = playerControls.Player.Move.ReadValue<Vector2>();

        float horizontalInput = playerMove.y;
        float verticalInput = playerMove.x;

        transform.Translate(playerSpeed * Time.deltaTime * Vector3.forward * horizontalInput);
        transform.Translate(playerSpeed * Time.deltaTime * Vector3.right * verticalInput);
    }
}
