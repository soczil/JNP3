using UnityEngine;

public class MenuRobot : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private int speedAnimatorId = Animator.StringToHash("Speed");
    private int groundAnimatorId = Animator.StringToHash("Ground");

    void Awake()
    {
        animator.SetFloat(speedAnimatorId, 8f);
        animator.SetBool(groundAnimatorId, true);
    }
}
