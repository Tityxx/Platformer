using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public bool isMusic;
	private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ValueChange(); });
        if (isMusic) slider.value = AudioManager.musicVol;
        else slider.value = AudioManager.soundsVol;
    }
    private void ValueChange()
	{
        if (isMusic)
        {
            AudioManager.setMusicVolume(slider.value);
            AudioManager.musicVol = slider.value;
        }
        else
        {
            AudioManager.setSoundVolume(slider.value);
            AudioManager.soundsVol = slider.value;
        }
    }
}
