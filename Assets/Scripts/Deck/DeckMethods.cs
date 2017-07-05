using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMethodAttribute : Attribute
{
}

public class DeckMethods
{
    public DeckMethods()
    {
    }

    [DeckMethod]
    public static void Mage_Armor()
    {
        //  Console.WriteLine("{0} called Mage_Armor via Spell {1}, {2}", Caster.Name, Spell.ID, Spell.Name);
    }
}
