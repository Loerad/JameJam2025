using UnityEngine;


public class enemyController : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] bool isMoving;
    Vector3 direction = Vector3.right;
    [SerializeField] public float Speed = 1f;
    [SerializeField] GameObject enemy;
    private bool hasTurned;

    void Update()
    {
        if (PauseManager.Instance.pauseState == PauseState.Paused) { return; } //also pause animation
        if (isMoving)
        {
            transform.position += Speed * Time.deltaTime * direction;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            direction *= -1f;
            if (!hasTurned) 
            { 
                transform.localScale = new Vector3(-1f, 1f, 1f);
                hasTurned = true;
            }
            else
            {
                transform.localScale = Vector3.one;
                hasTurned = false;
            }
        }
    }
}
