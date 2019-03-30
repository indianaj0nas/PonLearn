using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnselectArea : MonoBehaviour
{

    public GameObject[] horseParts;

    void Start()
    {
        FindAllHorseParts();
    }

    void OnMouseDown()
    {
        DeselectObjects();
    }

    void DeselectObjects()
    {
        for (int i = 0; i < horseParts.Length; i++)
        {
            horseParts[i].GetComponent<HorsePart>().UnSelectPart();
        }
    }

    void FindAllHorseParts()
    {
        horseParts = GameObject.FindGameObjectsWithTag("HorsePart");
    }
}
