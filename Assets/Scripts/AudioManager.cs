using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Clips")]
    public AudioClip jumpClip;
    public AudioClip slideClip;
    public AudioClip deathClip;
    public AudioClip pacaClip;
    public AudioClip powerUpClip;
    public AudioClip backgroundMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PlayMusic();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic()
    {
        if (backgroundMusic == null) return;

        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

}
