using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setAnimationParameters : MonoBehaviour
{
    [SerializeField] private Animator animator;
    AnimatorStateInfo animStateInfo;
    bool jumpIsFinished;
    bool isFalling;

    public float NTime;


    // Use this for initialization
    void Start()
    {
        isFalling = false;
    }

    void Update()
    {

        bool climbBox = Input.GetKey(KeyCode.C);
        bool isClimbingLedge = Input.GetKey(KeyCode.X);
        bool isJumpDown = Input.GetKey(KeyCode.Space);
        jumpIsFinished = false;


        animator.SetBool("IsClimbBox", climbBox);
        animator.SetBool("isClimbingLedge", isClimbingLedge);
        animator.SetBool("IsJumpingDown", isJumpDown);
        animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        NTime = animStateInfo.normalizedTime;

        if (NTime > 1.0f && animator.GetCurrentAnimatorStateInfo(0).IsName("Jumping Down"))
            jumpIsFinished = true;
        if (jumpIsFinished == true)
        {
            isFalling = true;
        }
        if (NTime > 1.0f && animator.GetCurrentAnimatorStateInfo(0).IsName("Falling Idle"))
            isFalling = false;

        animator.SetBool("IsFalling", isFalling);

    }


}
