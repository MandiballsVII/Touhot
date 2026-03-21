using UnityEngine;

public class AmbienceIntensity : MonoBehaviour
{
    private float intensity = 0.5f;
    private string parameterName = "wind_intensity";

    float timer = 0f;
    void Update()
    {
        if (timer > 3f)
        {
            intensity = Random.Range(0f, 1f);
            AudioManager.Instance.SetAmbienceParameter(parameterName, intensity);
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }
}
