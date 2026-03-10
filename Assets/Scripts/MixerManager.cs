using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerManager : MonoBehaviour
{

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string exposedMusicParamName;
    [SerializeField] private string exposedSFXParamName;

    private void OnEnable()
    {
        SyncSlidersFromMixer();
    }


    public void SetMusicVolume()
    {
        float volume = Mathf.Log10(Mathf.Max(musicSlider.value, 0.001f)) * 20f;
        mixer.SetFloat(exposedMusicParamName, volume);
        Debug.Log($"New Music Volume: {volume}");
    }

    public void SetSFXVolume()
    {
        float volume = Mathf.Log10(Mathf.Max(sfxSlider.value, 0.001f)) * 20f; 
        mixer.SetFloat(exposedSFXParamName, volume);
        Debug.Log($"New SFX Volume: {volume}");
    }


    private void SyncSlidersFromMixer() 
    {
        float musicDb, sfxDb;

        mixer.GetFloat(exposedMusicParamName, out musicDb);
        mixer.GetFloat(exposedSFXParamName, out sfxDb); 

        
        musicSlider.SetValueWithoutNotify(DbToLinear(musicDb));
        sfxSlider.SetValueWithoutNotify(DbToLinear(sfxDb));
    }

    private float DbToLinear (float db)
    {
        float linear = Mathf.Pow(10, db / 20f);
        if (linear < 0.001f) linear = 0f;

        return linear; 
    }
}

