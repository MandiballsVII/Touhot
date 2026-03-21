using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    GameObject[] eyes;
    int deadEyes = 0;

    private void Start()
    {
        eyes = GameObject.FindGameObjectsWithTag("EnemyEye");
    }

    public void CheckVulnerableStatus()
    {
        deadEyes = 0;
        for(int i = 0; i < eyes.Length; i++)
        {
            if (eyes[i].GetComponent<EnemyEyeLogic>().isBroken) 
            { 
                deadEyes++;
            }
        }
        if(deadEyes == eyes.Length) 
        {
            GetComponent<EnemyLife>().vulnerable = true;
            Debug.Log("ahora es vulnerable");
        }
    }
}
