using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUtility : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene("Level");
    }

    public void CloseGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void PressButtonSfx()
    {
        AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.ButtonPress, transform.position);
    }

    public void HoverButtonSfx()
    {
        AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.ButtonHover, transform.position);
    }

}
