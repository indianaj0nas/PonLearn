using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateScene : MonoBehaviour
{
    public GameObject sceneTransition;
    public bool useFadeIn;

    private Animator animator;

    void Start()
    {
        animator = sceneTransition.GetComponent<Animator>();

        sceneTransition.SetActive(true);
        
        if (useFadeIn == true)
            animator.SetBool("UseFadeIn", true);
        else
            animator.SetBool("UseFadeIn", false);

    }
}
