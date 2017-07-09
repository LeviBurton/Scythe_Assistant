using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public List<ECardType> AllowedCardTypes;

    public void OnDrop(PointerEventData EventData)
    {
    }

    public void OnPointerEnter(PointerEventData EventData)
    {
        if (EventData.pointerDrag == null)
            return;

        // TODO: 
        // Add highlights to valid drop zones

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

        // TODO: 
        // Remove highlights to valid drop zones

        var Draggable = EventData.pointerDrag.GetComponent<Draggable>();
        if (Draggable != null && Draggable.PlaceHolderParent == this.transform)
        {   
            Draggable.PlaceHolderParent = Draggable.ParentToReturnTo;
        }
    }
}
