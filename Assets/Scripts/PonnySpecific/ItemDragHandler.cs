using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject spriteObject;
    public string horsePart;

    private Vector3 startPosition;
    private RectTransform rectTransform;
    private GameObject parentObj;
    private GameObject canvas;
    private bool overTrigger = false;
    private GameHandler gameHandler;

    void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
        parentObj = transform.parent.gameObject;
        canvas = GameObject.Find("Canvas");
    }



    public void OnDrag(PointerEventData evenData)
    {
        gameHandler.currentPart = horsePart;
        transform.SetParent(canvas.transform);
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        /* Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPoint2D = new Vector2(worldPoint.x, worldPoint.y); */
        transform.SetParent(parentObj.transform);
        rectTransform.anchoredPosition = startPosition;
    }
}
