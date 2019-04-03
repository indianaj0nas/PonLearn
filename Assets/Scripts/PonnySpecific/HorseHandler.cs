using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseHandler : MonoBehaviour
{
    public enum HorseMode
    {
        normal,
        skeleton,
        muscles,
        transparent
    }

    public HorseMode currentMode;

    private GameObject[] horseParts;

    void Start()
    {
        currentMode = HorseMode.normal;
    }

    public void UpdatePartsMode(string modeName)
    {
        currentMode = (HorseMode)System.Enum.Parse(typeof(HorseMode), modeName); ;
        horseParts = GameObject.FindGameObjectsWithTag("HorsePart");

        for (int i = 0; i < horseParts.Length; i++)
        {
            horseParts[i].GetComponent<HorsePart>().ChangedMode(currentMode.ToString());
        }
    }
}
