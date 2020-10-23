using UnityEngine;

public class Play : MonoBehaviour
{
    public static bool first = true;
    void Start()
    {
        if (first)
        {
            string music = "music_" + Random.Range(0, AudioManager.maxQtyMusic).ToString();
            AudioManager.Play(music);
            AudioManager.LoadVolume();
            GameManager.instance.LoadSettings();
            first = false;
        }
    }
    void OnMouseDown()
    {
        GameManager.instance.LoadNewScene("Level1", false);
    }
}
