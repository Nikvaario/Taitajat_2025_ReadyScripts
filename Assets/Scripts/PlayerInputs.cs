using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private PlayerMovement playerMovement; // Reference to PlayerMovement script in object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Movement Input Action Function
    public void OnMovement(InputAction.CallbackContext value)
    {
        playerMovement.Direction = value.ReadValue<float>();
    }

    // Jump Input Action Function
    public void OnJump(InputAction.CallbackContext value)
    {
        if (playerMovement.isGrounded)
        {
            playerMovement.Jump();
        }
    }
}
