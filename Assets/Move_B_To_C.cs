using UnityEngine;

public class Move_B_To_C : StateMachineBehaviour
{
    Transform endPostition;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    float stopRange = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        endPostition = GameManager.instance.EnemyTransform_C.transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 direction = new Vector2(endPostition.position.x - rb.transform.position.x, endPostition.position.y - rb.transform.position.y);
        rb.linearVelocity = direction.normalized * moveSpeed;

        if (Vector2.Distance(rb.transform.position, endPostition.position) < stopRange)
        {
            animator.SetTrigger("StopMoving");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.linearVelocity = Vector2.zero;
        animator.ResetTrigger("StopMoving");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
