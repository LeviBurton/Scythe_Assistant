using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Reflection;

public enum CardType
{
    Automa,
    Tracker,
    Reference,
}

public enum Facing
{
    Front,
    Back
}

public class Card : MonoBehaviour, IPointerClickHandler
{
    public CardType CardType;

    private Image FrontImage;
    private Image BackImage;
    private bool bFaceUp;
    public bool FaceUp
    {
        get
        {
            return bFaceUp;
        }
        set
        {
            bFaceUp = value;

            if (bFaceUp == true)
            {
                FrontImage.enabled = true;
                BackImage.enabled = false;
            }
            else
            {
                FrontImage.enabled = false;
                BackImage.enabled = true;
            }
        }
    }

    public void FlipCard()
    {
        FaceUp = !FaceUp;
    }

    public void OnPointerClick(PointerEventData EventData)
    {
        FlipCard();
    }

    void Start ()
    {
        var ImageComponents = GetComponentsInChildren<Image>();

        foreach (var Image in ImageComponents)
        {
            if (Image.name == "Image_Front")
            {
                FrontImage = Image;
            }
            else if (Image.name == "Image_Back")
            {
                BackImage = Image;
            }
        }

        bFaceUp = false;

        var Draggable = GetComponent<Draggable>();
        if (Draggable != null)
        {
            Draggable.OnDragHandler += this.OnDrag;
            Draggable.OnBeginDragHandler += this.OnBeginDrag;
            Draggable.OnEndDragHandler += this.OnEndDrag;
        }
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
