using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePart : MonoBehaviour
{

    public string partName;
    public bool selected = false;
    public GameObject partObj;

    [System.Serializable]
    public class PartState
    {
        public Vector3 statePosition;
        public Sprite stateSprite;
        public string stateDescription;
        public Vector3 descriptionPosition;
        public GameObject selectorObj;
        public Vector3 selectorPosition;
        public Sprite selectorSprite;
    }

    [SerializeField]
    public List<PartState> partStates = new List<PartState>();

    private GameObject descriptionObj;
    private Camera cameraObj;
    private GameObject stateContainer;
    private PartState currentState;
    private SpriteRenderer spriteRenderer;
    private SuperTextMesh descriptionText;

    void Start()
    {
        cameraObj = GameObject.Find("Main Camera").GetComponent<Camera>();
        descriptionObj = GameObject.Find("Canvas/Description");
        descriptionText = descriptionObj.transform.GetChild(0).GetComponent<SuperTextMesh>();
        spriteRenderer = partObj.GetComponent<SpriteRenderer>();

        InitiatePartStates();
    }

    void OnMouseDown()
    {
        SelectedPart();
    }

    void InitiatePartStates()
    {
        stateContainer = new GameObject("StatesContainer");
        stateContainer.transform.parent = gameObject.transform;
        stateContainer.transform.localPosition = Vector3.zero;
        stateContainer.SetActive(false);

        for (int i = 0; i < partStates.Count; i++)
        {
            GameObject selector = partStates[i].selectorObj = new GameObject("Selector" + i);
            selector.AddComponent<SpriteRenderer>();
            selector.AddComponent<SelectorButton>();
            selector.GetComponent<SelectorButton>().stateNumber = i;
            selector.GetComponent<SelectorButton>().horsePartHandler = gameObject;
            selector.GetComponent<SpriteRenderer>().sortingLayerName = "Button";
            selector.transform.parent = stateContainer.transform;
            selector.transform.localPosition = partStates[i].selectorPosition;
            selector.GetComponent<SpriteRenderer>().sprite = partStates[i].selectorSprite;
        }
    }

    public void SetState(int stateNumber)
    {
        currentState = partStates[stateNumber];

        spriteRenderer.sprite = currentState.stateSprite;
        partObj.transform.localPosition = currentState.statePosition;
        descriptionObj.transform.position = cameraObj.GetComponent<Camera>().WorldToScreenPoint(currentState.descriptionPosition);
        descriptionText.text = currentState.stateDescription;
    }

    void SelectedPart()
    {
        stateContainer.gameObject.SetActive(true);
    }
}
