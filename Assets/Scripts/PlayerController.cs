using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    public bool CantMove;
    public bool AtPot;
    public GameObject Enemy;

    public GameObject doorToOpenFromPot;

    public bool atDoorPot;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private List<GameObject> ladderBlockers = new();
    [SerializeField]
    private SpriteRenderer spriteBody;
    [SerializeField]
    private SpriteRenderer spriteFace;

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
                foreach (GameObject blocker in ladderBlockers)
                {
                    blocker.GetComponent<BoxCollider>().enabled = false;
                }
            }
            else
            {
                state = PlayerState.normal;
            }
        }
    }
    public void OnInteract2(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Started)
        {
            if (AtPot)
            {
                CantMove = !CantMove;
                if (CantMove)
                {
                    animator.SetTrigger("EnterPot");
                }
                else
                {
                    animator.SetTrigger("LeavePot");
                }
                if (atDoorPot)
                {
                    doorToOpenFromPot.GetComponent<DoorController>().Unlock();
                }
                if (Enemy != null)
                {
                    Destroy(Enemy);
                }
            }
        }
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        if(context.action.phase == InputActionPhase.Started)
        {
            SceneManager.LoadScene("Menu");
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

        if (!IsWall || state == PlayerState.normal)
        {
            state = PlayerState.normal;
            foreach (GameObject blocker in ladderBlockers)
            {
                blocker.GetComponent<BoxCollider>().enabled = true;
            }
            if (!groundedPlayer)
            {
                playerVelocity.y += GRAVITY * Time.deltaTime;
            }
        }

        finalMove = (move * playerSpeed) + (playerVelocity.y * Vector2.up);
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.position.z);
        if (CantMove)
        {
            controller.Move(playerVelocity * Time.deltaTime);
            return;
        }

        controller.Move(finalMove * Time.deltaTime);
        HandleAnimation();
    }

    void HandleAnimation()
    {
        if (move.x < 0f)
        {
            spriteBody.flipX = true;
            spriteFace.flipX = true;
        }
        else if (move.x > 0f)
        {
            spriteBody.flipX = false;
            spriteFace.flipX = false;
        }
        if (move == Vector2.zero)
        {
            animator.SetTrigger("Idle");
        }
        else
        {
            animator.SetTrigger("Walk");
        }
    }
}
