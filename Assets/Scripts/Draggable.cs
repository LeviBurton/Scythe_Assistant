using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void Delegate_OnBeginDrag(PointerEventData EventData);
public delegate void Delegate_OnDrag(PointerEventData EventData);
public delegate void Delegate_OnEndDrag(PointerEventData EventData);

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform ParentToReturnTo = null;
    public GameObject PlaceHolder = null;
    public Transform PlaceHolderParent = null;

    public Delegate_OnDrag OnDragHandler = null;
    public Delegate_OnBeginDrag OnBeginDragHandler = null;
    public Delegate_OnEndDrag OnEndDragHandler = null;

    public void OnBeginDrag(PointerEventData EventData)
    {
        if (OnBeginDragHandler != null)
        {
            OnBeginDragHandler(EventData);
            return;
        }

        PlaceHolder = new GameObject();
        PlaceHolder.transform.SetParent(this.transform.parent);
        LayoutElement LayoutElement = PlaceHolder.AddComponent<LayoutElement>();
        LayoutElement.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        LayoutElement.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        LayoutElement.flexibleWidth = 0;
        LayoutElement.flexibleHeight = 0;

        PlaceHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
       
        ParentToReturnTo = this.transform.parent;
        PlaceHolderParent = ParentToReturnTo;

        transform.SetParent(this.transform.parent.parent);

        var CanvasGroup = GetComponent<CanvasGroup>();
        CanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData EventData)
    {
        if (OnDragHandler != null)
        {
            OnDragHandler(EventData);
            return;
        }

        transform.position = EventData.position;

        if (PlaceHolder.transform.parent != PlaceHolderParent)
        {
            PlaceHolder.transform.SetParent(PlaceHolderParent);
        }

        int NewSiblingIndex = PlaceHolderParent.childCount;

        for (int i = 0; i < PlaceHolderParent.childCount; i++)
        {
            if (this.transform.position.x < PlaceHolderParent.GetChild(i).position.x)
            {
                NewSiblingIndex = i;
                if (PlaceHolder.transform.GetSiblingIndex() < NewSiblingIndex)
                {
                    NewSiblingIndex--;
                }

                break;
            }
        }

        PlaceHolder.transform.SetSiblingIndex(NewSiblingIndex);
    }

    public void OnEndDrag(PointerEventData EventData)
    {
        if (OnBeginDragHandler != null)
        {
            OnBeginDragHandler(EventData);
            return;
        }

        transform.SetParent(ParentToReturnTo);
        transform.SetSiblingIndex(PlaceHolder.transform.GetSiblingIndex());
        var CanvasGroup = GetComponent<CanvasGroup>();
        CanvasGroup.blocksRaycasts = true;
        Destroy(PlaceHolder);
    }
}
