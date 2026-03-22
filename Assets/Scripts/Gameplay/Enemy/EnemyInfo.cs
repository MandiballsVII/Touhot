using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    GameObject[] eyes;
    int deadEyes = 0;
    CapsuleCollider2D capsuleCollider;

    private void Start()
    {
        eyes = GameObject.FindGameObjectsWithTag("EnemyEye");
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        
        if (GetComponent<EnemyLife>().vulnerable)
        {
            capsuleCollider.enabled = true;
        }
        else
        {
            capsuleCollider.enabled = false;
        }
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
            capsuleCollider.enabled = true;
            Debug.Log("ahora es vulnerable");
        }
    }
}
