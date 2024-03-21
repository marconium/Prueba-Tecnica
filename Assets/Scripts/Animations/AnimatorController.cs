using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : Singleton<AnimatorController>
{
    [Header("Animator Reference")]
    public Animator animator;
   
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

   
    public void Pause()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.speed = 0;
    }

    public void UnPause()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.speed = 1;
    }


    public void Play(GlobalEnum.AnimationId animationId)
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.Play(animationId.ToString());       
    }
}
