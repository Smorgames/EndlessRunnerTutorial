using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _boom;
    [SerializeField] private AudioSource _lose;
    [SerializeField] private AudioSource _mainTheme;

    private AudioSource _audioSource;

    private void Awake()
    {
        var anotherAudioManager = FindObjectOfType<AudioManager>();

        if (anotherAudioManager != null && anotherAudioManager != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _mainTheme.Play();
    }

    public void Boom()
    {
        _boom.Play();
    }

    public void Lose()
    {
        _lose.Play();
    }
}