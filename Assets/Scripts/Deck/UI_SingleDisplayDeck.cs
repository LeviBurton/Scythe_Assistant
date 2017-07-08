using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SingleDisplayDeck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Discard_OnClick()
    {
        var CurrentCard = GetComponentInChildren<CardBehavior>();

        if (CurrentCard == null)
            return;

        Debug.Log("Discarding " + CurrentCard.name);
    }
}
