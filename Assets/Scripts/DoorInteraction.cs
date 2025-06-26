using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteraction : MonoBehaviour
{
    bool atDoor;
    bool atExitDoor;
    GameObject currentDoor;
    public void ReceiveDoor(GameObject door, bool isGameExit, bool isLocked)
    {
        if (isLocked)
        {
            return;
        }
        if (isGameExit)
        {
            atExitDoor = true;
        }
        currentDoor = door;
        atDoor = true;
        
    }


    public void ForgetDoor()
    {
        currentDoor = null;
        atDoor = false;
        atExitDoor = false;
    }

    public void RoomChange(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Started)
        {
            if (atExitDoor)
            {
                #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
                #else
                Application.Quit(); //needs change to go to main menu
                #endif
            }
            else if (atDoor)
            {
                currentDoor.GetComponent<DoorController>().OnInteraction();
            }
        }
    }
}
