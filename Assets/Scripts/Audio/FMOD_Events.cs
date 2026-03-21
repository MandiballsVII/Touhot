using UnityEngine;
using FMODUnity;

public class FMOD_Events : MonoBehaviour
{
    [field: Header("Player")]
    [field: SerializeField] public EventReference PlayerShoot { get; private set; }
    public static FMOD_Events Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Multiple instances of FMOD_Events detected. Destroying duplicate.");
            Destroy(gameObject);
        }
    }


}
