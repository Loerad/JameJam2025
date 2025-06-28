using System.Collections;
using UnityEngine;


public class enemyController : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] bool isMoving;
    Vector3 direction = Vector3.right;
    public float Speed = 1f;
    [SerializeField] GameObject enemy;
    [SerializeField]
    private Animator animator;
    private bool hasTurned;
    bool isWaiting;
    float waitTime = 3;

    void Update()
    {
        if (PauseManager.Instance.pauseState == PauseState.Paused) { animator.speed = 0; return; } //also pause animation
        else { animator.speed = 1; }
        if (isWaiting) { return; }
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
            isWaiting = true;
            StartCoroutine(WaitBeforeTurn());
        }
    }

    IEnumerator WaitBeforeTurn()
    {
        float time = 0f;
        while (time < waitTime) //https://discussions.unity.com/t/pause-coroutine-and-keep-waitforseconds-the-same/950494/2 < life saver
        {
            yield return null;
            if (PauseManager.Instance.pauseState == PauseState.Paused)
            {
                continue;
            }
            time += Time.deltaTime;
        }
        isWaiting = false;

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
