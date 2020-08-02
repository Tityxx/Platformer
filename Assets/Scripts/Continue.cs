using UnityEngine;

public class Continue : MonoBehaviour
{
    public GameObject pauseMenu;

    void OnMouseDown()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
