using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private RoomManager roomManager;
    [SerializeField]
    private DoorController connectedDoor;
    [SerializeField]
    private int roomIndex;
    private GameObject player;

    void Start()
    {
        roomManager = GameObject.Find("Main Camera").GetComponent<RoomManager>();
        player = GameObject.Find("Player");
    }

    public void OnInteraction()//may need callback
    {
        player.transform.position = connectedDoor.transform.position;
    }
}
