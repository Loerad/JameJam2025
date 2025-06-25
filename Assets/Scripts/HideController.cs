using UnityEngine;
using UnityEngine.InputSystem;

public class HideController : MonoBehaviour
{
    GameObject Player;
    PlayerControlller controller;
    private void Start()
    {
        Player = transform.GetChild(0).gameObject;
        controller = GetComponent<PlayerControlller>();
    }
    public void OnHide(InputAction.CallbackContext context)
    {
        int layerHidden = LayerMask.NameToLayer("Hidden");
        int layerVisable = LayerMask.NameToLayer("Default");
        if (context.action.phase == InputActionPhase.Started)
        {

            if (Player.layer != layerHidden)
            {
                Player.layer = layerHidden;
                controller.CantMove = true;
            }
            else
            {
                Player.layer = layerVisable;
                controller.CantMove = false;
            }
        }
    }
    void Update()
    {


    }
}
