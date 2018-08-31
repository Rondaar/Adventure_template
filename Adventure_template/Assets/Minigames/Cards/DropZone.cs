using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public void OnDrop(PointerEventData eventData)
    {
        /* Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
         if (d != null)
         {
             d.initParent = transform;
         }*/
        //TODO: implement other characters reactions to cards
        Debug.Log("Dropped");
        Destroy(eventData.pointerDrag.GetComponent<Draggable>().dummyCard);
        Destroy(eventData.pointerDrag);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                d.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                d.transform.localScale = new Vector3(1f, 1f, 1);
            }
        }
    }


}
