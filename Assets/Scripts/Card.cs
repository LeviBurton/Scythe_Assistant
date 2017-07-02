using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public enum Facing
{
    Front,
    Back
}

public class Card : MonoBehaviour, IPointerClickHandler
{
    public Image FrontImage;
    public Image BackImage;

    public bool bFaceUp;

    public void SetOrientation(bool bFaceUp)
    {
        this.bFaceUp = bFaceUp;
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

    public void FlipCard()
    {
        SetOrientation(!bFaceUp);    
    }

    public void OnPointerClick(PointerEventData EventData)
    {
        FlipCard();
    }

    // Use this for initialization
    void Start () {
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
	}
	
	// Update is called once per frame
	void Update () {
    
    }
}
