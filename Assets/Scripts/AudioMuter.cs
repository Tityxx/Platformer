using UnityEngine;

public class AudioMuter : MonoBehaviour
{
    public bool isMusic = true;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}
