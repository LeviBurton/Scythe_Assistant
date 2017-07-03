using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardManagerBehavior : MonoBehaviour {

    public GameObject CardPrefab;
    public GameObject Canvas;
    public List<CardBehavior> CardBehaviors = new List<CardBehavior>();

    private void InitCardBehavior(CardBehavior InCardBehavior, Card InCard)
    {
        InCardBehavior.Card = InCard;
        InCardBehavior.GetImageComponents();
        InCardBehavior.FrontImageComponent.sprite = InCard.ImageFront;
        InCardBehavior.BackImageComponent.sprite = InCard.ImageBack;
        InCardBehavior.SetFacing(false);
    }

    void Start ()
    {
        CardManager.Instance.RefreshAssets();

        var AutomaCards = CardManager.Instance.Items.Where(x => x.CardType == ECardType.Automa).ToList();
        var ReferenceCards = CardManager.Instance.Items.Where(x => x.CardType == ECardType.Reference).ToList();
        var TrackerCards = CardManager.Instance.Items.Where(x => x.CardType == ECardType.Tracker).ToList();

        var AllCards = CardManager.Instance.Items.ToList();

        foreach (var Card in AllCards)
        {
            var Spawned = Instantiate(CardPrefab, Canvas.transform);
            var CardBehavior = Spawned.GetComponent<CardBehavior>();

            InitCardBehavior(CardBehavior, Card);

            CardBehaviors.Add(CardBehavior);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
