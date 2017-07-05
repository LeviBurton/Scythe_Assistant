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


        InCardBehavior.SetFacing(true);
    }

    void Start ()
    {
        CardManager.Instance.RefreshAssets();

        var AutomaCards = CardManager.Instance.Items.Where(x => x.CardType == ECardType.Automa).ToList();
        var ReferenceCards = CardManager.Instance.Items.Where(x => x.CardType == ECardType.Reference).ToList();
        var TrackerCards = CardManager.Instance.Items.Where(x => x.CardType == ECardType.Tracker).ToList();
        var AllCards = CardManager.Instance.Items.ToList();
        var DeckList = FindObjectsOfType<UI_Deck>();

        foreach (var Deck in DeckList)
        {
            if (Deck.name == "AutomaDeck")
            {
                AutomaDeck = Deck;
            }
            else if (Deck.name == "AutomaDiscardDeck")
            {
                AutomaDiscardDeck = Deck;
            }
            else if (Deck.name == "TrackerDeck")
            {
                TrackerDeck = Deck;
            }
            else if (Deck.name == "ReferenceDeck")
            {
                ReferenceDeck = Deck;
            }
            else if (Deck.name == "SingleDisplayDeck")
            {
                SingleDisplayDeck = Deck;
            }
        }

        for (int i = 0; i < AllCards.Count; i++)
        {
            var Card = AllCards[i];
            Transform DeckTransform = null;

            if (Card.CardType == ECardType.Automa)
            {
                DeckTransform = AutomaDeck.transform;
            }
            else if (Card.CardType == ECardType.Reference)
            {
                DeckTransform = ReferenceDeck.transform;
            }
            else if (Card.CardType == ECardType.Tracker)
            {
                DeckTransform = TrackerDeck.transform;
            }

            // Testing
            if (i == 0)
            {
                DeckTransform = SingleDisplayDeck.transform;
            }

            var Spawned = Instantiate(CardPrefab, DeckTransform);

            // Testing
            if (DeckTransform != SingleDisplayDeck.transform)
            {
                Spawned.transform.localScale /= 4;
            }

            var CardBehavior = Spawned.GetComponent<CardBehavior>();

            InitCardBehavior(CardBehavior, Card);
            CardBehaviors.Add(CardBehavior);
            Spawned.transform.SetSiblingIndex(i);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
