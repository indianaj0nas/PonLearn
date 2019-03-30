using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackBox : MonoBehaviour
{
    public GameObject cameraObj;
    public AnimationCurve animCurve;
    public float animSpeed = 1f;
    public bool jumpToPoint;

    public void MoveToPoint(Vector3 targetPos)
    {
        Vector3 targetPosition = cameraObj.GetComponent<Camera>().WorldToScreenPoint(targetPos);
        if (!jumpToPoint)
            transform.position = targetPosition + Vector3.up * 1.5f;
        IEnumerator move = MoveToPoint(gameObject, transform.position, targetPosition, animCurve, animSpeed);
        StartCoroutine(move);
    }

    public IEnumerator MoveToPoint(GameObject moveThis, Vector3 pos1, Vector3 pos2, AnimationCurve ac, float time)
    {
        float timer = 0.0f;
        while (timer <= time)
        {
            moveThis.transform.position = Vector3.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
