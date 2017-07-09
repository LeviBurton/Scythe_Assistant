using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardManagerBehavior : MonoBehaviour {

    public GameObject CardPrefab;
    public GameObject Canvas;
    public List<CardBehavior> CardBehaviors = new List<CardBehavior>();

    public UI_Deck AutomaDeck;
    public UI_Deck AutomaDiscardDeck;
    public UI_Deck TrackerDeck;
    public UI_Deck ReferenceDeck;
    public UI_Deck SingleDisplayDeck;

    private void InitCardBehavior(CardBehavior InCardBehavior, Card InCard)
    {
        InCardBehavior.Card = InCard;
        InCardBehavior.GetImageComponents();
        InCardBehavior.FrontImageComponent.sprite = InCard.ImageFront;
        InCardBehavior.BackImageComponent.sprite = InCard.ImageBack;
    }

    void Start()
    {
        CardManager.Instance.RefreshAssets();

        var AutomaCards = CardManager.Instance.Items.Where(x => x.CardType == ECardType.Automa).ToList();
        var ReferenceCards = CardManager.Instance.Items.Where(x => x.CardType == ECardType.Reference).ToList();
        var TrackerCards = CardManager.Instance.Items.Where(x => x.CardType == ECardType.Tracker).ToList();
        var AllCards = CardManager.Instance.Items.ToList();

        AutomaDeck = GameObject.Find("AutomaDeck").GetComponent<UI_Deck>();
        AutomaDiscardDeck = GameObject.Find("AutomaDiscardDeck").GetComponent<UI_Deck>();
        TrackerDeck = GameObject.Find("TrackerDeck").GetComponent<UI_Deck>();
        ReferenceDeck = GameObject.Find("ReferenceDeck").GetComponent<UI_Deck>();
        SingleDisplayDeck = GameObject.Find("SingleDisplayDeck").GetComponent<UI_Deck>();

        for (int i = 0; i < AutomaCards.Count;i++)
        {
            var Card = AutomaCards.ElementAt(i);
            var Spawned = Instantiate(CardPrefab, AutomaDeck.transform);
            var CardBehavior = Spawned.GetComponent<CardBehavior>();
            var RectTransform = (RectTransform)CardBehavior.transform;

            // Set card width and height to deck width and height
            RectTransform.sizeDelta = ((RectTransform)AutomaDeck.transform).sizeDelta;

            CardBehavior.SetFacing(false);
            InitCardBehavior(CardBehavior, Card);
            CardBehaviors.Add(CardBehavior);
          //  Spawned.transform.SetSiblingIndex(i);
            Spawned.name = Card.name;
        }

        for (int i = 0; i < TrackerCards.Count; i++)
        {
            var Card = TrackerCards.ElementAt(i);
            var Spawned = Instantiate(CardPrefab, TrackerDeck.transform);
            var CardBehavior = Spawned.GetComponent<CardBehavior>();
            var RectTransform = (RectTransform)CardBehavior.transform;

            CardBehavior.SetFacing(true);

            // Set card width and height to deck width and height
            RectTransform.sizeDelta = ((RectTransform)TrackerDeck.transform).sizeDelta;

            InitCardBehavior(CardBehavior, Card);
            CardBehaviors.Add(CardBehavior);
         //   Spawned.transform.SetSiblingIndex(i);
            Spawned.name = Card.name;
        }

        for (int i = 0; i < ReferenceCards.Count; i++)
        {
            var Card = ReferenceCards.ElementAt(i);
            var Spawned = Instantiate(CardPrefab, ReferenceDeck.transform);
            var CardBehavior = Spawned.GetComponent<CardBehavior>();
            var RectTransform = (RectTransform)CardBehavior.transform;

            // Set card width and height to deck width and height
            RectTransform.sizeDelta = ((RectTransform)ReferenceDeck.transform).sizeDelta;
            CardBehavior.SetFacing(true);
            InitCardBehavior(CardBehavior, Card);
            CardBehaviors.Add(CardBehavior);
            //Spawned.transform.SetSiblingIndex(i);
            Spawned.name = Card.name;
        }
    }
}
