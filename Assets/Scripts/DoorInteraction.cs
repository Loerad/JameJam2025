using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteraction : MonoBehaviour
{
    bool atDoor;
    GameObject currentDoor;
    public void ReceiveDoor(GameObject door)
    {
        currentDoor = door;
        atDoor = true;
    }

    public void ForgetDoor()
    {
        currentDoor = null;
        atDoor = false;
    }

    public void RoomChange(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Started)
        {
            if (atDoor)
            {
                currentDoor.GetComponent<DoorController>().OnInteraction();
            }
        }
    }
}
