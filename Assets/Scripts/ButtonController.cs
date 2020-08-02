using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject musicSettings;

    public void ClickMusic()
    {
        musicSettings.SetActive(true);
    }
}
