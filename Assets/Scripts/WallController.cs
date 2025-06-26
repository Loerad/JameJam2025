using UnityEngine;

public class WallController : MonoBehaviour
{
    PlayerControlller player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControlller>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.IsWall = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        { 
            player.IsWall = false;
        }
    }
}
