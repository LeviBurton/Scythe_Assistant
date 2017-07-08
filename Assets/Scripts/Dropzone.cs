using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData EventData)
    {
        // Get the deck
        var Deck = GetComponent<UI_Deck>();

        if (Deck != null)
        {
            if (Deck.name == "AutomaDiscardDeck")
            {

            }
        }
        var Draggable = EventData.pointerDrag.GetComponent<Draggable>();
        if (Draggable != null)
        {
            Draggable.ParentToReturnTo = this.transform;
            var RectTransform = (RectTransform)Draggable.transform;

            // Set card width and height to deck width and height
            RectTransform.sizeDelta = ((RectTransform)this.transform).sizeDelta;

            var Card = Draggable.GetComponent<CardBehavior>();

            Card.SetFacing(true);
            Draggable.transform.SetSiblingIndex(0);
        }
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
