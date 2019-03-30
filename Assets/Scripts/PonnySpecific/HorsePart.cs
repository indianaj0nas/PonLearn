using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorsePart : MonoBehaviour
{

    public string partName;
    public bool selected = false;
    public GameObject partObj;
    public Sprite corretIcon;
    public Sprite wrongIcon;
    public GameObject selectorContainer;
    public float selectorButtonAnimSpeed;
    public AnimationCurve selectorAnimCurve;

    [System.Serializable]
    public class PartState
    {
        public GameObject selectorButton;
        public Vector3 statePosition;
        public Sprite stateSprite;
        public string stateDescription;
        public Vector3 descriptionPosition;
        [HideInInspector]
        public Vector3 selectorPosition;
        public Sprite selectorSpriteEmpty;
        public Sprite selectorSpriteFilled;
        public bool correctState;
    }

    [SerializeField]
    public List<PartState> partStates = new List<PartState>();

    private GameObject descriptionObj;
    private Camera cameraObj;
    private PartState currentState;
    private SpriteRenderer spriteRenderer;
    private SuperTextMesh descriptionText;

    void Start()
    {
        cameraObj = GameObject.Find("Main Camera").GetComponent<Camera>();
        descriptionObj = GameObject.Find("Canvas/FeedbackBox");
        descriptionText = descriptionObj.transform.GetChild(0).GetComponent<SuperTextMesh>();
        descriptionObj.SetActive(false);
        spriteRenderer = partObj.GetComponent<SpriteRenderer>();

        InitiatePartStates();
    }

    void OnMouseDown()
    {
        SelectedPart();
    }

    void InitiatePartStates()
    {
        selectorContainer.SetActive(false);

        for (int i = 0; i < partStates.Count; i++)
        {
            GameObject selector = partStates[i].selectorButton;
            partStates[i].selectorPosition = partStates[i].selectorButton.transform.localPosition;
            selector.GetComponent<SelectorButton>().stateNumber = i;
            selector.GetComponent<SelectorButton>().horsePartHandler = gameObject;
            //selector.transform.localPosition = partStates[i].selectorPosition;
            selector.GetComponent<SpriteRenderer>().sprite = partStates[i].selectorSpriteEmpty;
        }
    }

    public void SetState(int stateNumber)
    {
        for (int i = 0; i < partStates.Count; i++)
        {
            if (i == stateNumber)
            {
                partStates[i].selectorButton.GetComponent<SpriteRenderer>().sprite = partStates[i].selectorSpriteFilled;
            }
            else
            {
                partStates[i].selectorButton.GetComponent<SpriteRenderer>().sprite = partStates[i].selectorSpriteEmpty;
            }
        }

        currentState = partStates[stateNumber];

        spriteRenderer.sprite = currentState.stateSprite;
        partObj.transform.localPosition = currentState.statePosition;
        descriptionObj.SetActive(true);
        //descriptionObj.transform.position = cameraObj.GetComponent<Camera>().WorldToScreenPoint(currentState.descriptionPosition);
        descriptionObj.GetComponent<FeedbackBox>().MoveToPoint(currentState.descriptionPosition);
        descriptionText.text = currentState.stateDescription;
        Image imageComp = descriptionObj.transform.GetChild(1).gameObject.GetComponent<Image>();

        if (currentState.correctState == true)
        {
            imageComp.color = Color.green;
            imageComp.sprite = corretIcon;
        }
        else
        {
            imageComp.color = Color.red;
            imageComp.sprite = wrongIcon;
        }
    }

    void SelectedPart()
    {
        StartCoroutine("SelectedPartFeedback");
        selectorContainer.gameObject.SetActive(true);
        for (int i = 0; i < partStates.Count; i++)
        {
            IEnumerator move = MoveToPoint(partStates[i].selectorButton, selectorContainer.transform.localPosition, partStates[i].selectorPosition, selectorAnimCurve, selectorButtonAnimSpeed);
            StartCoroutine(move);
        }
    }

    public void UnSelectPart()
    {
        SetState(0);
        for (int i = 0; i < partStates.Count; i++)
        {
            IEnumerator move = MoveToPoint(partStates[i].selectorButton, partStates[i].selectorPosition, selectorContainer.transform.localPosition, selectorAnimCurve, selectorButtonAnimSpeed);
            StartCoroutine(move);
        }
        Invoke("DeactiveOnUnselect", selectorButtonAnimSpeed / 2);
        descriptionObj.SetActive(false);
    }

    void DeactiveOnUnselect()
    {
        selectorContainer.gameObject.SetActive(false);
    }

    IEnumerator SelectedPartFeedback()
    {
        partObj.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        partObj.GetComponent<SpriteRenderer>().color = Color.gray;
        yield return new WaitForSeconds(0.1f);
        partObj.transform.localScale = new Vector3(1f, 1f, 1f);
        partObj.GetComponent<SpriteRenderer>().color = Color.white;
        yield return null;
    }

    public IEnumerator MoveToPoint(GameObject moveThis, Vector3 pos1, Vector3 pos2, AnimationCurve ac, float time)
    {
        float timer = 0.0f;
        while (timer <= time)
        {
            moveThis.transform.localPosition = Vector3.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
