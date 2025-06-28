using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;
    public List<GameObject> respawnPoints = new();
    private GameObject currentSpawn;
    [SerializeField]
    private GameObject player;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        currentSpawn = respawnPoints[0]; //the 0th respawn point should always be first in the list
    }

    public void SetRespawn(GameObject point)
    {
        currentSpawn = point;
    }

    public void Respawn()
    {
        CharacterController cc = player.GetComponent<CharacterController>();
        cc.enabled = false;
        player.transform.position = currentSpawn.transform.position;
        cc.enabled = true;
    }
}
