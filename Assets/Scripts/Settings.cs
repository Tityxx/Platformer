using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    void OnMouseDown()
    {
        GameManager.instance.LoadNewScene("Settings", false);
    }
}
