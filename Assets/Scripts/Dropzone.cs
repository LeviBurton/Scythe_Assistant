using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData EventData)
    {
        var Draggable = EventData.pointerDrag.GetComponent<Draggable>();
        if (Draggable != null)
        {
            Draggable.ParentToReturnTo = this.transform;
        }
    }

    public void OnPointerEnter(PointerEventData EventData)
    {
        if (EventData.pointerDrag == null)
            return;

        var Draggable = EventData.pointerDrag.GetComponent<Draggable>();
        if (Draggable != null)
        {
            Draggable.PlaceHolderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData EventData)
    {
        if (EventData.pointerDrag == null)
            return;

        var Draggable = EventData.pointerDrag.GetComponent<Draggable>();
        if (Draggable != null && Draggable.PlaceHolderParent == this.transform)
        {   
            Draggable.PlaceHolderParent = Draggable.ParentToReturnTo;
        }
    }
}
