using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private GameObject connectedDoor;
    [SerializeField]
    private int connectedDoorRoomIndex;
    [SerializeField]
    private GameObject startingGlyph;
    [SerializeField]
    private GameObject onGlyph = null; //can be null cause some doors dont have toggleable states
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
        if (isGameExit)
        {
            SceneManager.LoadScene("Menu");
        }
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = connectedDoor.transform.position + new Vector3(0, 1.1f, 0);
        player.GetComponent<CharacterController>().enabled = true;
        RoomManager.Instance.ChangeRoom(RoomManager.Instance.GetCurrentRoomFromIndex(connectedDoorRoomIndex));
    }

    public void Unlock()
    {
        isLocked = false;
        startingGlyph.SetActive(false);
        onGlyph.SetActive(true);
        if (!isGameExit)
        {
            DoorController door = connectedDoor.GetComponent<DoorController>();
            door.isLocked = false;
            door.startingGlyph.SetActive(false);
            door.onGlyph.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactor.ReceiveDoor(gameObject, isGameExit, isLocked);
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
