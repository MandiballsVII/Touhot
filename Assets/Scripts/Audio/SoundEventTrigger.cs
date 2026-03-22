using UnityEngine;
using FMODUnity;
public class SoundEventTrigger : MonoBehaviour
{
    [SerializeField] private EventReference soundEvent;
    [SerializeField] private bool playOnStart = true;

    private void Start()
    {
        if (playOnStart)
            InitializeSoundEvent();
    }

    public void InitializeSoundEvent()
    {
        AudioManager.Instance.InitializeAmbience(soundEvent);
    }
}
