using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField]
    GameObject connectedRespawnPoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RespawnManager.Instance.SetRespawn(connectedRespawnPoint);
        }
    }
}
