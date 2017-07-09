using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Deck : MonoBehaviour,  IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public List<ECardType> AllowedCardTypes;
    public List<CardBehavior> Cards;

    public bool CanDragFrom = true;
    public bool CanDragTo = true;

    public void AddCard(CardBehavior Card)
    {
        Cards.Add(Card);
    }

    public void OnDrop_SingleDisplayDeck(BaseEventData EventData)
    {
        var PointerEventData = EventData as PointerEventData;
        var Draggable = PointerEventData.pointerDrag.GetComponent<Draggable>();

        if (Draggable == null)
        {
            return;
        }

        OnDrop(PointerEventData);
    }

    public void OnDrop(PointerEventData EventData)
    {
        var Draggable = EventData.pointerDrag.GetComponent<Draggable>();

        if (Draggable == null)
        {
            return;
        }

        var CardBehavior = Draggable.GetComponent<CardBehavior>();
        if (CardBehavior != null)
        {
            OnDrop_Card(EventData, CardBehavior);
        }
    }

    public void OnDrop_Card(PointerEventData EventData, CardBehavior Card)
    {
        if (AllowedCardTypes.Contains(Card.Card.CardType))
        {
            var CardRectTransform = (RectTransform)Card.transform;

            Card.GetComponent<Draggable>().ParentToReturnTo = this.transform;
            CardRectTransform.SetParent(transform);
            CardRectTransform.transform.SetParent(transform);
            CardRectTransform.transform.SetAsLastSibling();
            CardRectTransform.sizeDelta = ((RectTransform)this.transform).sizeDelta;
            Card.SetFacing(true);
            Cards.Add(Card);
        }
    }

    public void OnReferenceDeckClicked(BaseEventData EventData)
    {
        Debug.Log("UI_Deck::OnReferenceDeckClicked: " + EventData.ToString());
    }

    public void OnTrackerDeckClicked(BaseEventData EventData)
    {
        Debug.Log("UI_Deck::OnTrackerDeckClicked: " + EventData.ToString());
    }

    public void OnPointerEnter(PointerEventData EventData)
    {

    }

    public void OnPointerExit(PointerEventData EventData)
    {
    }

    // Use this for initialization
    void Start () {
  
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}


//EventTrigger trigger = GetComponent<EventTrigger>();
//if (trigger != null)
//{
//    EventTrigger.Entry entry = new EventTrigger.Entry();
//    entry.eventID = EventTriggerType.PointerDown;
//    entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
//    trigger.triggers.Add(entry);
//}