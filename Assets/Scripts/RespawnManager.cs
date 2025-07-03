using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;
    public List<GameObject> respawnPoints = new();
    private GameObject currentSpawn;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private Transform camPos1, camPos2;
    private Transform camPosition;

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
        if (currentSpawn == respawnPoints[0] || currentSpawn == respawnPoints[2])
        {
            camPosition = camPos1;
        }
        else
        {
            camPosition = camPos2;
        }
        cam.transform.position = camPosition.position;
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
        cc.enabled = true;
    }
}
