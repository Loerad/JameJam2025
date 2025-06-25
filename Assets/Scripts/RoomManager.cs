using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;
    private GameObject currentRoom;
    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private List<GameObject> rooms = new();
    int roomIndex = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void ChangeRoom(GameObject roomToChange)
    {
        currentRoom = roomToChange;
        cam.transform.position = currentRoom.transform.position;
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
    }

    public GameObject GetCurrentRoomFromIndex(int index)
    {
        return rooms[index];
    }


}
