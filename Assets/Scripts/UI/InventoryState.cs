using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryState : MonoBehaviour
{

    public RectTransform inventory;
    public AnimationCurve movementCurve;
    public float movementSpeed;
    public Vector3 openPosition;
    public Vector3 closedPosition;
    public string openText;
    public string closeText;
    public TextMeshProUGUI buttonText;

    private bool open = false;

    public void ButtonClick()
    {
        if (open)
        {
            IEnumerator move = MoveToPoint(inventory, openPosition, closedPosition, movementCurve, movementSpeed);
            StartCoroutine(move);
            buttonText.text = closeText;
            open = false;
        }
        else
        {
			IEnumerator move = MoveToPoint(inventory, closedPosition, openPosition, movementCurve, movementSpeed);
            StartCoroutine(move);
            buttonText.text = openText;
            open = true;
        }
    }

    public IEnumerator MoveToPoint(RectTransform moveThis, Vector3 pos1, Vector3 pos2, AnimationCurve ac, float time)
    {
        float timer = 0.0f;
        while (timer <= time)
        {
            moveThis.anchoredPosition = Vector3.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
