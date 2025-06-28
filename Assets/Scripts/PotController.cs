using UnityEngine;
using UnityEngine.InputSystem;

public class PotController : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject door;
    [SerializeField] bool isDoorPot;
    public GameObject onGlyph;
    public GameObject startingGlyph;
    PlayerControlller controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller = collision.gameObject.GetComponentInParent<PlayerControlller>();
            controller.AtPot = true;
            if (isDoorPot)
            {
                controller.atDoorPot = true;
                controller.doorToOpenFromPot = door;
                controller.currentPot = this;

            }
            else
            {
                controller.Enemy = Enemy;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller = collision.gameObject.GetComponentInParent<PlayerControlller>();
            controller.AtPot = false;
            if (Enemy != null)
            {
                controller.Enemy = null;
            }
            controller.atDoorPot = false;
            controller.doorToOpenFromPot = null;
            controller.currentPot= null;
        }
    }
}
