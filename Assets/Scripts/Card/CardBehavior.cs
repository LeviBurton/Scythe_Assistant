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
        SetFacing(true);
    }

    #region Drag Handling
    public void OnBeginDrag(PointerEventData EventData)
    {
        Debug.Log(this.name + " OnBeginDrag");
    }
    public void OnDrag(PointerEventData EventData)
    {
        Debug.Log(this.name + " OnDrag");
    }
    public void OnEndDrag(PointerEventData EventData)
    {
        Debug.Log(this.name + " OnEndDrag");
    }
    #endregion

    void Update ()
    {
    
    }
}
