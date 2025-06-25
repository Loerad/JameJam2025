using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] PlayerControlller player;
    void Update()
    {
        
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
