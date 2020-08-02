using UnityEngine;
using UnityEngine.SceneManagement;

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
            first = false;
        }
    }
    void OnMouseDown()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
