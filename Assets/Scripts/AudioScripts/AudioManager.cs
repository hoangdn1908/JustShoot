using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Background Music")]
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameplayMusic;

    [Header("Weapon Sound")]
    [SerializeField] private AudioClip shortGunSound;
    [SerializeField] private AudioClip basicGunSound;
    [SerializeField] private AudioClip shootGunSound;

    [Header("Game sound")]
    [SerializeField] private AudioClip gameoverSound;

    private void Awake()
    {
        SetSingleton();
    }

    private void SetSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void PlayMusic(AudioClip musicClip)
    {
        if (musicClip == null)
            return;
        if (musicSource.clip == musicClip && musicSource.isPlaying)
            return;
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    private void PlaySFX(AudioClip sfxClip)
    {
        if (sfxClip == null)
            return;
        sfxSource.PlayOneShot(sfxClip);
    }

    #region Weapon sound
    public void PlayShortGunSound() => PlaySFX(shortGunSound);
    public void PlayBasicGunSound() => PlaySFX(basicGunSound);
    public void PlayShotGunSound() => PlaySFX(shootGunSound);
    #endregion

    #region Background music
    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic);
    }

    public void PlayGameplayMusic()
    {
        PlayMusic(gameplayMusic);
    }
    #endregion

    #region Game sound
    public void PlayGameOverSound()
    {
        StopMusic();
        PlaySFX(gameoverSound);
    }
    #endregion
}
