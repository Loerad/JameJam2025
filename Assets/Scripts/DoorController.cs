using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private DoorController connectedDoor;
    [SerializeField]
    private int connectedDoorRoomIndex;
    private GameObject player;
    private DoorInteraction interactor;

    void Start()
    {
        player = GameObject.Find("Player");
        interactor = player.GetComponent<DoorInteraction>();
    }

    public void OnInteraction()//may need callback
    {
        player.transform.position = connectedDoor.transform.position;
        RoomManager.Instance.ChangeRoom(RoomManager.Instance.GetCurrentRoomFromIndex(connectedDoorRoomIndex));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactor.ReceiveDoor(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            interactor.ForgetDoor();
        }
    }
}
