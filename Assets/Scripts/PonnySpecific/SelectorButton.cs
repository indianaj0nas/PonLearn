using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorButton : MonoBehaviour
{
    public int stateNumber;
    public GameObject horsePartHandler;

    void OnMouseDown()
    {
        SendStateChange();
        StartCoroutine("ClickFeedback");
    }

    void SendStateChange()
    {
        horsePartHandler.GetComponent<HorsePart>().SetState(stateNumber);
    }

    IEnumerator ClickFeedback()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        GetComponent<SpriteRenderer>().color = Color.gray;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return null;
    }
}
