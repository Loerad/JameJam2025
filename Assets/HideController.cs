using UnityEngine;
using UnityEngine.InputSystem;

public class HideController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public void OnHide(InputAction.CallbackContext context)
    {
        int layerHidden = LayerMask.NameToLayer("Hidden");
        int layerVisable = LayerMask.NameToLayer("Default");
        if (context.action.phase == InputActionPhase.Started)
        {

            if (Player.layer != layerHidden)
            {
                Player.layer = layerHidden;
                Debug.Log("Hidden");
            }
            else
            {
                Player.layer = layerVisable;
                Debug.Log("visable");
            }
        }
    }
    void Update()
    {


    }
}
