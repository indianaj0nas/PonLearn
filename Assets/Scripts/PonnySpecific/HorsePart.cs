using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePart : MonoBehaviour
{

    public string partName;

    private GameHandler gameHandler;

    void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }

    void OnMouseEnter()
    {
        if (gameHandler.currentPart == partName)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
