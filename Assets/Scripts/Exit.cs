using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    void OnMouseDown()
    {
        GameManager.instance.LoadNewScene("Menu", false);
        Time.timeScale = 1f;
    }
}
