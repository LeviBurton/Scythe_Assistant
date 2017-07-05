using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Reflection;


public enum Facing
{
    Front,
    Back
}

public class CardBehavior : MonoBehaviour
{
    public Card Card;
    public Image FrontImageComponent;
    public Image BackImageComponent;
    public Draggable Draggable;
    public CanvasGroup CanvasGroup;

    public int SiblingIndex = 0;

    public void SetFacing(bool Up)
    {
        if (FrontImageComponent == null || BackImageComponent == null)
            return;

        FrontImageComponent.enabled = Up;
        BackImageComponent.enabled = !Up;
    }

    public void GetImageComponents()
    {
        var ImageComponents = GetComponentsInChildren<Image>();

        foreach (var Component in ImageComponents)
        {
            if (Component.name == "Image_Front")
            {
                FrontImageComponent = Component;
            }
            else if (Component.name == "Image_Back")
            {
                BackImageComponent = Component;
            }
        }
    }

    void Start ()
    {
        Draggable = GetComponent<Draggable>();
        CanvasGroup = GetComponent<CanvasGroup>();

        if (Draggable != null)
        {
            Draggable.OnBeginDragHandler += OnBeginDrag;
            Draggable.OnDragHandler += OnDrag;
            Draggable.OnEndDragHandler += OnEndDrag;
        }
    }

    #region Drag Handling
    public void OnBeginDrag(PointerEventData EventData)
    {
        Draggable.ParentToReturnTo = this.transform.parent;
        SiblingIndex = transform.GetSiblingIndex();

        // FIXME!
        transform.SetParent(this.transform.parent.parent.parent.parent);
        CanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData EventData)
    {
        Debug.Log(this.name + " OnDrag");
        var RectTransform = GetComponent<RectTransform>();
        RectTransform.position = EventData.position;

        //transform = EventData.position;
    }
    public void OnEndDrag(PointerEventData EventData)
    {
        transform.SetParent(Draggable.ParentToReturnTo);
        transform.SetSiblingIndex(SiblingIndex);
        transform.position = Draggable.ParentToReturnTo.transform.position;

        CanvasGroup.blocksRaycasts = true;
    }
    #endregion

    void Update ()
    {
    
    }
}
