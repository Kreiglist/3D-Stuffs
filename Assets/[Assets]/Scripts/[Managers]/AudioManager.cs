using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    [SerializeField] private AudioSource audioObject;

    private void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
        }
        else Destroy(gameObject);
    }
    public void PlayAudio(AudioClip audioClip, Transform spawn, float volume)
    {
        AudioSource audioSource = Instantiate(audioObject, spawn.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float cliplen = audioSource.clip.length;
        Destroy(audioSource.gameObject, cliplen);
    }
    public void PlayAudioRandom(AudioClip[] audioClips, Transform spawn, float volume)
    {
        int rand = Random.Range(0, audioClips.Length);
        AudioSource audioSource = Instantiate(audioObject, spawn.position, Quaternion.identity);
        audioSource.clip = audioClips[rand];
        audioSource.volume = volume;
        audioSource.Play();
        float cliplen = audioSource.clip.length;
        Destroy(audioSource.gameObject, cliplen);
    }
}