using UnityEngine;
using UnityEngine.InputSystem;

public class PotController : MonoBehaviour
{
    [SerializeField] GameObject Enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerControlller>().AtPot = true;
            collision.gameObject.GetComponentInParent<PlayerControlller>().Enemy = Enemy;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerControlller>().AtPot = false;
            if (Enemy != null)
            {
                collision.gameObject.GetComponentInParent<PlayerControlller>().Enemy = null;
            }
        }
    }
}
