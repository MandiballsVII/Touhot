using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        Master,
        Music,
        Ambience,
        SFX
    }

    [Header("Type")]
    [SerializeField] private VolumeType volumeType;

    private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider = this.GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        switch (volumeType)
        {
            case VolumeType.Master:
                volumeSlider.value = AudioManager.Instance.MasterVolume;
                break;
            case VolumeType.Music:
                volumeSlider.value = AudioManager.Instance.MusicVolume;
                break;
            case VolumeType.Ambience:
                volumeSlider.value = AudioManager.Instance.AmbienceVolume;
                break;
            case VolumeType.SFX:
                volumeSlider.value = AudioManager.Instance.SFXVolume;
                break;
            default:
                Debug.LogError("VolumeSlider: Invalid volume type." + volumeType);
                break;
        }
    }

    public void OnSliderValueChanged(float value)
    {
        switch (volumeType)
        {
            case VolumeType.Master:
                AudioManager.Instance.MasterVolume = volumeSlider.value;
                break;
            case VolumeType.Music:
                AudioManager.Instance.MusicVolume = volumeSlider.value;
                break;
            case VolumeType.Ambience:
                AudioManager.Instance.AmbienceVolume = volumeSlider.value;
                break;
            case VolumeType.SFX:
                AudioManager.Instance.SFXVolume = volumeSlider.value;
                break;
            default:
                Debug.LogError("VolumeSlider: Invalid volume type." + volumeType);
                break;
        }
    }
}
