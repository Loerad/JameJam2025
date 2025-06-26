using UnityEngine;
using UnityEngine.InputSystem;

public class PotController : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject door;
    [SerializeField] bool isDoorPot;
    public GameObject onGlyph;
    public GameObject startingGlyph;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerControlller>().AtPot = true;
            if (isDoorPot)
            {
                collision.gameObject.GetComponentInParent<PlayerControlller>().atDoorPot = true;
                collision.gameObject.GetComponentInParent<PlayerControlller>().doorToOpenFromPot = door;
                collision.gameObject.GetComponentInParent<PlayerControlller>().currentPot = this;

            }
            else
            {
                collision.gameObject.GetComponentInParent<PlayerControlller>().Enemy = Enemy;
            }

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
            collision.gameObject.GetComponentInParent<PlayerControlller>().atDoorPot = false;
            collision.gameObject.GetComponentInParent<PlayerControlller>().doorToOpenFromPot = null;
                            collision.gameObject.GetComponentInParent<PlayerControlller>().currentPot= null;
        }
    }
}
