using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    public static Dictionary<string, AudioMuter> music;
    public static AudioSource nowPlaying;
    public static float baseVolume = 0.3f;
    public static float musicVol = 0.3f, soundsVol = 0.3f;
    public static int maxQtyMusic;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            music = new Dictionary<string, AudioMuter>();
            GameObject[] musicArr = GameObject.FindGameObjectsWithTag("Music");
            foreach (GameObject audio in musicArr) music.Add(audio.name, audio.GetComponent<AudioMuter>());
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (!nowPlaying.isPlaying)
        {
            string music = "music_" + Random.Range(0, maxQtyMusic).ToString();
            Play(music);
        }
    }

    public static void Play(string audio)
    {
        AudioSource audioSource = music[audio].GetAudioSource();
        if(audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
            if (music[audio].isMusic) nowPlaying = audioSource;
        }
    }
    public static void setMusicVolume(float vol)
    {
        foreach(AudioMuter audio in music.Values)
        {
            if(audio.isMusic)
            {
                audio.GetAudioSource().volume = vol;
            }
        }
    }
    public static void setSoundVolume(float vol)
    {
        foreach (AudioMuter audio in music.Values)
        {
            if (!audio.isMusic)
            {
                audio.GetAudioSource().volume = vol;
            }
        }
    }
    public static void LoadVolume()
    {
        musicVol = PlayerPrefs.GetFloat("music");
        soundsVol = PlayerPrefs.GetFloat("sounds");
        if (musicVol == 0)
        {
            setMusicVolume(baseVolume);
            musicVol = baseVolume;
        }
        if (soundsVol == 0)
        {
            setSoundVolume(baseVolume);
            soundsVol = baseVolume;
        }
    }
    public static void SaveVolume()
    {
        PlayerPrefs.SetFloat("music", musicVol);
        PlayerPrefs.SetFloat("sounds", soundsVol);
    }
    private void OnApplicationQuit()
    {
        SaveVolume();
    }
}
