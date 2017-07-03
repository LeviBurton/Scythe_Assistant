using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Tools : ScriptableObject
{
    [MenuItem("Tools/Cards/Recreate Card Assets")]
    public static void RecreateCardAssets()
    {
        DeleteAll();

        var SpriteGuids = AssetDatabase.FindAssets("t:Sprite", new string[] { CardManager.TextureAssetsBasePath });
        List<Sprite> CardSrpites = new List<Sprite>();

        foreach (string ItemGuid in SpriteGuids)
        {
            var AssetPath = AssetDatabase.GUIDToAssetPath(ItemGuid);
            var Asset = AssetDatabase.LoadAssetAtPath<Sprite>(AssetPath);
            CardSrpites.Add(Asset);
        }

        int AutomaCardCount = 19;
        var ImageBack = CardSrpites.SingleOrDefault(x => x.name == string.Format("AutomaCards_r4-Panda-{0}", AutomaCardCount + 1));
        for (int i = 1; i <= AutomaCardCount; i++)
        {
            string SourceImageName = string.Format("AutomaCards_r4-Panda-{0}", i.ToString("00"));
            var ImageFront = CardSrpites.SingleOrDefault(x => x.name == SourceImageName);
            var Name = string.Format("Automa_{0}", i);
            var CardAsset = CreateAsset<Card>(Name);

            CardAsset.CardType = ECardType.Automa;
            CardAsset.ImageBack = ImageBack;
            CardAsset.ImageFront = ImageFront;
            CardAsset.Name = Name;
            CardAsset.name = Name;

            SaveAsset<Card>(CardAsset);
        }

        int ReferenceCount = 8;
        ImageBack = CardSrpites.SingleOrDefault(x => x.name == string.Format("AutomaReference_r6-Panda-{0}", ReferenceCount + 1));
        for (int i = 1; i <= ReferenceCount; i++)
        {
            string SourceImageName = string.Format("AutomaReference_r6-Panda-{0}", i);
            var ImageFront = CardSrpites.SingleOrDefault(x => x.name == SourceImageName);
            var Name = string.Format("Reference_{0}", i);
            var CardAsset = CreateAsset<Card>(Name);

            CardAsset.CardType = ECardType.Reference;
            CardAsset.ImageBack = ImageBack;
            CardAsset.ImageFront = ImageFront;
            CardAsset.Name = Name;
            CardAsset.name = Name;

            SaveAsset<Card>(CardAsset);
        }

        int TrackerCount = 4;
        ImageBack = CardSrpites.SingleOrDefault(x => x.name == string.Format("AutomaStarTrackerCards_r3-Panda-{0}", TrackerCount + 1));
        for (int i = 1; i <= TrackerCount; i++)
        {
            string SourceImageName = string.Format("AutomaStarTrackerCards_r3-Panda-{0}", i);
            var ImageFront = CardSrpites.SingleOrDefault(x => x.name == SourceImageName);
            var Name = string.Format("Tracker_{0}", i);
            var CardAsset = CreateAsset<Card>(Name);

            CardAsset.CardType = ECardType.Tracker;
            CardAsset.ImageBack = ImageBack;
            CardAsset.ImageFront = ImageFront;
            CardAsset.Name = Name;
            CardAsset.name = Name;
            SaveAsset<Card>(CardAsset);
        }
    }

    public static void DeleteAll()
    {
        // Delete all assets
        var ItemGuids = AssetDatabase.FindAssets("t:Card", new string[] { CardManager.AssetsBasePath });
        foreach (string ItemGuid in ItemGuids)
        {
            var AssetPath = AssetDatabase.GUIDToAssetPath(ItemGuid);
            AssetDatabase.DeleteAsset(AssetPath);
        }
    }

    public static void SaveAsset<T>(T Asset) where T : Card
    {
        var AssetPath = AssetDatabase.GetAssetPath(Asset);
        if (string.IsNullOrEmpty(AssetPath))
        {
            AssetPath = CardManager.AssetsBasePath + string.Format(@"/{0}.asset", Asset.Name.Replace(" ", "_"));
            AssetDatabase.CreateAsset(Asset, AssetPath);
        }

        var AssetFileName = Path.GetFileNameWithoutExtension(AssetPath);

        if (Asset.Name != AssetFileName.Replace("_", " "))
        {
            var NewFileName = "/" + Asset.Name.Replace(" ", "_");
            AssetDatabase.RenameAsset(AssetPath, NewFileName);
        }

        AssetDatabase.SaveAssets();
    }

    public static T CreateAsset<T>(string Name, bool bOnlyCreateInstance = false) where T : Card
    {
        var AssetPath = CardManager.AssetsBasePath + string.Format(@"/{0}.asset", Name.Replace(" ", "_"));
        T ItemAsset = ScriptableObject.CreateInstance<T>();
        if (!bOnlyCreateInstance)
        {
            AssetDatabase.CreateAsset(ItemAsset, AssetPath);
        }
        return ItemAsset;
    }

}