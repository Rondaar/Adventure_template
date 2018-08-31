using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    [SerializeField]
    private float yPos = 14f;

    private Vector2 initPos;

    private bool dragging = false;

    [HideInInspector]
    public Transform initParent;

    [HideInInspector]
    public GameObject dummyCard;

    public void OnBeginDrag(PointerEventData eventData)
    {

        dragging = true;
        initParent = transform.parent;
        dummyCard = (GameObject)Instantiate(Resources.Load("DummyCard"));
        dummyCard.transform.SetParent(initParent);
        dummyCard.transform.SetSiblingIndex(transform.GetSiblingIndex());
        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        dragging = true;
 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
        transform.SetParent(initParent);
        transform.SetSiblingIndex(dummyCard.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(dummyCard);

    }

  

    void Update()
    {
        if (!dragging)
        {
            Align();
        }
        else
        {
            GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
            
        }
       
    }
    
    private void Align()
    {

        RectTransform rTr = GetComponent<RectTransform>();
        Vector3 screenPos = Camera.main.WorldToViewportPoint(rTr.position);
        rTr.rotation = Quaternion.Euler(rTr.eulerAngles.x, rTr.eulerAngles.y, -rTr.localPosition.x / 20);
        rTr.transform.localPosition = new Vector3(rTr.transform.localPosition.x, yPos - Mathf.Abs(rTr.localPosition.x / 10), rTr.localPosition.z);
        //Debug.Log(rTr.localPosition)
    }

}
