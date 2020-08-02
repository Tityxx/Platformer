using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
}
