using System.Collections.Generic;
using UnityEngine;

public class CardManager 
{
    #region Singleton
    private static CardManager _Instance;
    public static CardManager Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new CardManager();

            return _Instance;
        }
    }
    #endregion

    public static string AssetsBasePath = @"Assets/Resources/Data/Cards";
    public static string ResourcesBasePath = @"Data/Cards";

    public static string TextureAssetsBasePath = @"Assets/Textures/Cards";

    public List<Card> Items = new List<Card>();
    public List<CardBehavior> SpawnedCards = new List<CardBehavior>();

    public CardManager() {}

    public void RefreshAssets()
    {
        Items = new List<Card>();
        Items.AddRange(Resources.LoadAll<Card>(ResourcesBasePath));
    }
}






