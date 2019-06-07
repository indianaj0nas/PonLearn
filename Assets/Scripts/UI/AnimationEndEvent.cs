using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEndEvent : MonoBehaviour
{
    public UnityEvent onAnimationEnd;

    private Animator animator;
    private bool animationDone;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("NoState") && !animationDone)
        {
            onAnimationEnd.Invoke();
        }
    }
}
