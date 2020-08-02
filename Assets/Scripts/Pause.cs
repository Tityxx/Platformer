using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    void OnMouseDown()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
}
