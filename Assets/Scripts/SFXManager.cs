using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static SFXManager Instance { get; private set; }

    private AudioSource audioSource;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this; 

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        Debug.Log(clip.name);
        audioSource.PlayOneShot(clip); 
    }
}
