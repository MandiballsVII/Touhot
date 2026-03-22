using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float endGameDelay;
    public static GameManager instance;
    private GameObject player;
    public GameObject winGame;
    public GameObject loseScreen;
    public MenuUtility menuUtility;
    public RadialShotPattern[] patterns;
    public EnemyEyeLogic[] enemyEyes;

    public RadialShotWeapon[] mouthWeapon;

    [HideInInspector] public bool allEyesDead = false;

    public Transform EnemyTransform_A;
    public Transform EnemyTransform_B;
    public Transform EnemyTransform_C;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager Instance missing");
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public IEnumerator LoseGame()
    {
        loseScreen.SetActive(true);
        player.GetComponent<PlayerController>().controlsEnabled = false;           //Hay que desactivar los controles del jugador, y a ser posible, ocultar el sprite.
        AudioManager.Instance.CleanUp();
        AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.Lose, transform.position);
        yield return new WaitForSeconds(endGameDelay - 2);
        menuUtility.LoadScene("MainMenu");
    }

    public IEnumerator WinGame()
    {
        winGame.SetActive(true);
        player.GetComponent<PlayerController>().controlsEnabled = false;
        AudioManager.Instance.StopMusic(FMOD_Events.Instance.GameplayMusic);
        AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.WinGameMusic, transform.position);
        AudioManager.Instance.CleanUp();
        yield return new WaitForSeconds(endGameDelay);
        print("Volviendo al menú principal...");
        menuUtility.LoadScene("MainMenu");
    }
}
