using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class enemyController : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] bool isMoving;
    Vector3 direction = Vector3.right;
    [SerializeField] public float Speed = 1f;


    void Update()
    {
        if (isMoving)
        {
            transform.position += direction * Speed * Time.deltaTime;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("TEST1");

        if (collision.gameObject.CompareTag("Border")|| collision.gameObject.CompareTag("Player"))
        {
            direction *= -1f;
            Debug.Log("TEST2");
        }
    }
}
