using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [Header("Volume")]
    [Range(0f, 1f)]

    public float MasterVolume = 1f;
    [Range(0f, 1f)]

    public float MusicVolume = 1f;
    [Range(0f, 1f)]

    public float AmbienceVolume = 1f;
    [Range(0f, 1f)]

    public float SFXVolume = 1f;

    public Bus masterBus;
    public Bus musicBus;
    public Bus ambienceBus;
    public Bus sfxBus;
    public static AudioManager Instance { get; private set; }

    private List<EventInstance> eventInstances;

    private EventInstance ambienceEventInstance;

    private EventInstance musicEventInstance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Multiple instances of AudioManager detected. Destroying duplicate.");
            Destroy(gameObject);
        }

        eventInstances = new List<EventInstance>();

        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        ambienceBus = RuntimeManager.GetBus("bus:/Ambience");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
    }

    private void Start()
    {
        //InitializeAmbience(FMOD_Events.Instance.Wind);
        //InitializeMusic(FMOD_Events.Instance.MainMenuMusic);
    }

    private void Update()
    {
        masterBus.setVolume(MasterVolume);
        musicBus.setVolume(MusicVolume);
        ambienceBus.setVolume(AmbienceVolume);
        sfxBus.setVolume(SFXVolume);
    }

    public void InitializeAmbience(EventReference ambienceEventReference)
    {
        ambienceEventInstance = CreateEventInstance(ambienceEventReference);
        ambienceEventInstance.start();
    }

    public void SetAmbienceParameter(string parameterName, float value)
    {
        ambienceEventInstance.setParameterByName(parameterName, value);
    }

    public void InitializeMusic(EventReference musicEventReference)
    {
        if (musicEventInstance.isValid())
        {
            musicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            musicEventInstance.release();
        }

        musicEventInstance = CreateEventInstance(musicEventReference);
        musicEventInstance.start(); 
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    public void CleanUp()
    {
        foreach (var instance in eventInstances)
        {
            instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            instance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
}
