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

   
    public void Pause()// metodo para pausar animación
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.speed = 0;
    }

    public void UnPause()// metodo para desPausar animacion
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.speed = 1;
    }


    public void Play(GlobalEnum.AnimationId animationId)// metodo para iniciar animación
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.Play(animationId.ToString());       
    }
}
