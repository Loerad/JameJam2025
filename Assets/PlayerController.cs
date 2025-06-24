using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControlller : MonoBehaviour
{
    Vector2 moveAmount;
    [SerializeField] private float playerSpeed;
    private Vector2 playerVelocity;
    [SerializeField] Rigidbody2D rb;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();
    }
    private void Update()
    {
        Vector2 move = new Vector2(moveAmount.x, moveAmount.y);
        move.Normalize();
        Vector2 finalMove = ((move * playerSpeed) + (playerVelocity.y * Vector2.up) *Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.rotation.x,0, transform.position.z);
        rb.MovePosition(finalMove);
    }
}
