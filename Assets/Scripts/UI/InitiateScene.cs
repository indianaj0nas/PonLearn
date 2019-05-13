using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateScene : MonoBehaviour
{
    public GameObject sceneTransition;

    void Start()
    {
        sceneTransition.SetActive(true);
    }
}
