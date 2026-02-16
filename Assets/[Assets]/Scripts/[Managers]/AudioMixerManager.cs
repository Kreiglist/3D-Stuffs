using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerManager : MonoBehaviour
{
    public static AudioMixerManager mixerManager;
    // Serializable
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderSFX;
    private void Awake()
    {
        if (mixerManager == null)
        {
            mixerManager = this;
        }
        else Destroy(gameObject);
    }
    private void Start()
    {
        sliderMaster.value = PlayerPrefs.GetFloat("ValueMaster", 1f);
        SetMasterVolume(sliderMaster.value);
        sliderSFX.value = PlayerPrefs.GetFloat("ValueSFX", 1f);
        SetSFXVolume(sliderSFX.value);
    }

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("volumeMaster", Mathf.Log10(level) * 20f);
        PlayerPrefs.SetFloat("ValueMaster", level);
    }
    public void SetSFXVolume(float level)
    {
        audioMixer.SetFloat("volumeSFX", Mathf.Log10(level) * 20f);
        PlayerPrefs.SetFloat("ValueSFX", level);
    }
}
