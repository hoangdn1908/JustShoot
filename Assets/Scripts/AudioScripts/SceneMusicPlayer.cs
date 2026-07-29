using UnityEngine;

public class SceneMusicPlayer : MonoBehaviour
{
    public enum MusicType
    {
        Menu,
        Gameplay
    }

    [SerializeField] private MusicType musicType;

    private void Start()
    {
        if (AudioManager.Instance == null)
            return;

        switch (musicType)
        {
            case MusicType.Menu:
                AudioManager.Instance.PlayMenuMusic();
                break;

            case MusicType.Gameplay:
                AudioManager.Instance.PlayGameplayMusic();
                break;
        }
    }
}