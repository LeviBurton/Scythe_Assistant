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

    static string AssetsBasePath = @"Data/Cards";
    static string TextureAssetsBasePath = @"Assets/Textures/Cards";

    public List<Card> Items = new List<Card>();
    public List<CardBehavior> SpawnedCards = new List<CardBehavior>();

    public CardManager() {}

    public void RefreshAssets()
    {
        Items = new List<Card>();
        Items.AddRange(Resources.LoadAll<Card>(AssetsBasePath));
    }
}








//[MenuItem("Tools/Cards/Recreate Card Assets")]
//public static void RecreateCardAssets()
//{
//    CardManager.Instance.DeleteAll();

//    var SpriteGuids = AssetDatabase.FindAssets("t:Sprite", new string[] { TextureAssetsBasePath });
//    List<Sprite> CardSrpites = new List<Sprite>();

//    foreach (string ItemGuid in SpriteGuids)
//    {
//        var AssetPath = AssetDatabase.GUIDToAssetPath(ItemGuid);
//        var Asset = AssetDatabase.LoadAssetAtPath<Sprite>(AssetPath);
//        CardSrpites.Add(Asset);
//    }

//    int AutomaCardCount = 19;
//    var ImageBack = CardSrpites.SingleOrDefault(x => x.name == string.Format("AutomaCards_r4-Panda-{0}", AutomaCardCount+1));
//    for (int i = 1; i <= AutomaCardCount; i++)
//    {
//        string SourceImageName = string.Format("AutomaCards_r4-Panda-{0}", i.ToString("00"));
//        var ImageFront = CardSrpites.SingleOrDefault(x => x.name == SourceImageName);
//        var Name = string.Format("Automa_{0}", i);
//        var CardAsset = CardManager.Instance.CreateAsset<Card>(Name);

//        CardAsset.CardType = ECardType.Automa;
//        CardAsset.ImageBack = ImageBack;
//        CardAsset.ImageFront = ImageFront;
//        CardAsset.Name = Name;
//        CardAsset.name = Name;

//        CardManager.Instance.SaveAsset<Card>(CardAsset);
//    }

//    int ReferenceCount = 8;
//    ImageBack = CardSrpites.SingleOrDefault(x => x.name == string.Format("AutomaReference_r6-Panda-{0}", ReferenceCount+1));
//    for (int i = 1; i <= ReferenceCount; i++)
//    {
//        string SourceImageName = string.Format("AutomaReference_r6-Panda-{0}", i);
//        var ImageFront = CardSrpites.SingleOrDefault(x => x.name == SourceImageName);
//        var Name = string.Format("Reference_{0}", i);
//        var CardAsset = CardManager.Instance.CreateAsset<Card>(Name);

//        CardAsset.CardType = ECardType.Reference;
//        CardAsset.ImageBack = ImageBack;
//        CardAsset.ImageFront = ImageFront;
//        CardAsset.Name = Name;
//        CardAsset.name = Name;

//        CardManager.Instance.SaveAsset<Card>(CardAsset);
//    }

//    int TrackerCount = 4;
//    ImageBack = CardSrpites.SingleOrDefault(x => x.name == string.Format("AutomaStarTrackerCards_r3-Panda-{0}", TrackerCount+1));
//    for (int i = 1; i <= TrackerCount; i++)
//    {
//        string SourceImageName = string.Format("AutomaStarTrackerCards_r3-Panda-{0}", i);
//        var ImageFront = CardSrpites.SingleOrDefault(x => x.name == SourceImageName);
//        var Name = string.Format("Tracker_{0}", i);
//        var CardAsset = CardManager.Instance.CreateAsset<Card>(Name);

//        CardAsset.CardType = ECardType.Tracker;
//        CardAsset.ImageBack = ImageBack;
//        CardAsset.ImageFront = ImageFront;
//        CardAsset.Name = Name;
//        CardAsset.name = Name;
//        CardManager.Instance.SaveAsset<Card>(CardAsset);
//    }
//}

//public void DeleteAll()
//{
//    // Delete all assets
//    var ItemGuids = AssetDatabase.FindAssets("t:Card", new string[] { AssetsBasePath });
//    foreach (string ItemGuid in ItemGuids)
//    {
//        var AssetPath = AssetDatabase.GUIDToAssetPath(ItemGuid);
//        AssetDatabase.DeleteAsset(AssetPath);
//    }
//}

//public void SaveAsset<T>(T Asset) where T : Card
//{
//    var AssetPath = AssetDatabase.GetAssetPath(Asset);
//    if (string.IsNullOrEmpty(AssetPath))
//    {
//        AssetPath = AssetsBasePath + string.Format(@"/{0}.asset", Asset.Name.Replace(" ", "_"));
//        AssetDatabase.CreateAsset(Asset, AssetPath);
//    }

//    var AssetFileName = Path.GetFileNameWithoutExtension(AssetPath);

//    if (Asset.Name != AssetFileName.Replace("_", " "))
//    {
//        var NewFileName = "/" + Asset.Name.Replace(" ", "_");
//        AssetDatabase.RenameAsset(AssetPath, NewFileName);
//    }

//    AssetDatabase.SaveAssets();
//}

// Should handle all item types
//public T CreateAsset<T>(string Name, bool bOnlyCreateInstance = false) where T : Card
//{
//    var AssetPath = AssetsBasePath + string.Format(@"/{0}.asset", Name.Replace(" ", "_"));
//    T ItemAsset = ScriptableObject.CreateInstance<T>();
//    if (!bOnlyCreateInstance)
//    {
//        AssetDatabase.CreateAsset(ItemAsset, AssetPath);
//    }
//    return ItemAsset;
//}
