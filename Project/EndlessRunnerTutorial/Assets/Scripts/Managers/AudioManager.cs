using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BoomAudioSource;
    public AudioSource LoseAudioSource;
    public AudioSource MainThemeAudioSource;

    private void Awake()
    {
        var anotherAudioManager = FindObjectOfType<AudioManager>();

        if (anotherAudioManager != null && anotherAudioManager != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        MainThemeAudioSource.Play();
    }

    public void Boom()
    {
        BoomAudioSource.Play();
    }

    public void Lose()
    {
        LoseAudioSource.Play();
    }
}