using UnityEngine;

public enum PauseState
{
    UnPaused,
    Paused
}
public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;
    public static PauseState pauseState;
    [SerializeField]
    private GameObject menuUI;
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

    public void Pause()
    {
        pauseState = PauseState.Paused;
        menuUI.SetActive(true);
    }

    public void UnPause()
    {
        pauseState = PauseState.UnPaused;
        menuUI.SetActive(false);
    }
}
