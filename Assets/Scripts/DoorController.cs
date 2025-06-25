using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private GameObject connectedDoor;
    [SerializeField]
    private int connectedDoorRoomIndex;
    private GameObject player;
    private DoorInteraction interactor;
    [SerializeField]
    private bool isGameExit;
    [SerializeField]
    private bool isLocked;

    void Start()
    {
        player = GameObject.Find("Player");
        interactor = player.GetComponent<DoorInteraction>();
    }

    public void OnInteraction()//may need callback
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = connectedDoor.transform.position + new Vector3(0, 1.1f, 0);
        player.GetComponent<CharacterController>().enabled = true;
        RoomManager.Instance.ChangeRoom(RoomManager.Instance.GetCurrentRoomFromIndex(connectedDoorRoomIndex));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Cheese");
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
