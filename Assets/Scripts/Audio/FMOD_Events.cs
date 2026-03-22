using UnityEngine;
using FMODUnity;

public class FMOD_Events : MonoBehaviour
{
    [field: Header("Player")]
    [field: SerializeField] public EventReference PlayerShoot { get; private set; }

    [field: SerializeField] public EventReference ShipEngine { get; private set; }
    [field: SerializeField] public EventReference Lose { get; private set; }
    [field: SerializeField] public EventReference EyeDestroyed { get; private set; }
    [field: SerializeField] public EventReference Impact { get; private set; }
    [field: SerializeField] public EventReference Heal { get; private set; }

    [field: Header("UI")]
    [field: SerializeField] public EventReference ButtonPress { get; private set; }
    [field: SerializeField] public EventReference ButtonHover { get; private set; }


    [field: Header("Music")]
    [field: SerializeField] public EventReference MainMenuMusic { get; private set; }
    [field: SerializeField] public EventReference GameplayMusic { get; private set; }

    [field: Header("Environment")]
    [field: SerializeField] public EventReference Wind { get; private set; }
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
