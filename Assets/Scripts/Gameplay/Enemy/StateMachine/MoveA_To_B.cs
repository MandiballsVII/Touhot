using UnityEngine;

public class MoveA_To_B : StateMachineBehaviour
{
    Transform endPostition;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    float stopRange = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb= animator.GetComponent<Rigidbody2D>();
        endPostition = GameManager.instance.EnemyTransform_B.transform;

        for (int i = 0; i < GameManager.instance.enemyEyes.Length; i++)
        {
            if (!GameManager.instance.enemyEyes[i].isBroken)
            {
                if (i % 2 != 0)
                {
                    GameManager.instance.enemyEyes[i].eyeWeapon.shotPattern = GameManager.instance.patterns[1];
                }
                else
                {
                    GameManager.instance.enemyEyes[i].eyeWeapon.shotPattern = GameManager.instance.patterns[4];
                }

            }
            else
            {
                GameManager.instance.enemyEyes[i].eyeWeapon.shotPattern = GameManager.instance.patterns[4];
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 direction = new Vector2(endPostition.position.x - rb.transform.position.x, endPostition.position.y - rb.transform.position.y);
        rb.linearVelocity = direction.normalized * moveSpeed;

        if(Vector2.Distance(rb.transform.position, endPostition.position) < stopRange)
        {
            animator.SetTrigger("StopMoving");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.linearVelocity= Vector2.zero;
        animator.ResetTrigger("StopMoving");

        //Stop all Radial Shot Weapon pattern usage
        for (int i = 0; i < GameManager.instance.enemyEyes.Length; i++)
        {
            GameManager.instance.enemyEyes[i].GetComponentInChildren<RadialShotWeapon>().StopAllCoroutines();
            GameManager.instance.enemyEyes[i].eyeWeapon.shotPattern = GameManager.instance.patterns[4];
            GameManager.instance.enemyEyes[i].GetComponentInChildren<RadialShotWeapon>().onShotPattern = false;
        }
    }
}
