using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorButton : MonoBehaviour
{
    public int stateNumber;
    public GameObject horsePartHandler;

    void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnMouseDown()
    {
        SendStateChange();
    }

    void SendStateChange()
    {
        horsePartHandler.GetComponent<HorsePart>().SetState(stateNumber);
    }
}
