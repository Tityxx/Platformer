using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
