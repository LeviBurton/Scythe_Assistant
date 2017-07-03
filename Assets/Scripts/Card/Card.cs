using System;
using UnityEngine;

[Serializable]
public enum ECardType
{
    Automa,
    Tracker,
    Reference
}

[Serializable]
public class Card : ScriptableObject
{
    public ECardType CardType;
    public string Name;
    public Sprite ImageFront;
    public Sprite ImageBack;
}

