using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDescriptions : MonoBehaviour
{

    public GameObject[] deactivateThese;
    public GameObject[] activateThese;
    public GameObject hoverIndicator;

    void OnMouseDown()
    {
        if (hoverIndicator != null)
            hoverIndicator.gameObject.SetActive(false);
			
        for (int i = 0; i < activateThese.Length; i++)
        {
            activateThese[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < deactivateThese.Length; i++)
        {
            deactivateThese[i].gameObject.SetActive(false);
        }
    }

    void OnMouseEnter()
    {
        if (hoverIndicator != null)
            hoverIndicator.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        if (hoverIndicator != null)
            hoverIndicator.gameObject.SetActive(false);
    }
}
