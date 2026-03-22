using FMODUnity;
using UnityEngine;

public class OSTTrigger : MonoBehaviour
{

    [SerializeField] private EventReference musicEvent;
    [SerializeField] private bool playOnStart = true;

    private void Start()
    {
        if (playOnStart)
            PlayMusic();
    }

    public void PlayMusic()
    {
        AudioManager.Instance.InitializeMusic(musicEvent);
    }

}
