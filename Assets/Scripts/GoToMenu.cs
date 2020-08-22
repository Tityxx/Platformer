using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    void OnMouseDown()
    {
        GameManager.instance.LoadNewScene("Menu", false);
    }
}
