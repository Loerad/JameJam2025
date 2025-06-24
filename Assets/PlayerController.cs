using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public enum PlayerState
{
    normal,
    onWall
}
public class PlayerControlller : MonoBehaviour
{
    Vector2 moveAmount;
    [SerializeField] private float playerSpeed;
    private Vector2 playerVelocity;
    [SerializeField] CharacterController controller;
    public bool IsWall = false;
    Vector2 move;
    Vector2 finalMove;
    const float GRAVITY = -9.81f;
    bool groundedPlayer;
    PlayerState state;
    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Started)
        {
            if (IsWall && state == PlayerState.normal)
            {
                state = PlayerState.onWall;
            }
            else
            {
                state = PlayerState.normal;
            }
        }
    }
    private void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        if (state == PlayerState.onWall) 
        { 
            move = new Vector2(moveAmount.x, moveAmount.y);            
        }
        else
        {
            move = new Vector2(moveAmount.x, 0);
        }

        move.Normalize();
        if (move != Vector2.zero)
        {
            transform.right = move;
        }
        if (!IsWall|| state == PlayerState.normal)
        {
            state = PlayerState.normal;
            playerVelocity.y += GRAVITY * Time.deltaTime;
        }
        finalMove = ((move * playerSpeed) + (playerVelocity.y * Vector2.up));
        transform.rotation = Quaternion.Euler(transform.rotation.x,0, transform.position.z);
        controller.Move(finalMove * Time.deltaTime);
    }
}
