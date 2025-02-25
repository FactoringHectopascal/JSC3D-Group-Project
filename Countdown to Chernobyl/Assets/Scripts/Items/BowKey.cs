using UnityEngine;

public class BowKey : Item
{
    public BowKey()
    {
        icon = Resources.Load<Sprite>("Icons/KeyGreyShaft");
        itemName = "Bow of a Key";
        descriptionEasy = "This looks like the bow of a key, I might be able to attach this if I find the blade from it.";
        descriptionMedium = "This looks like the part of a key you apply torque to, I wonder where the rest is?";
        descriptionHard = "The beginning of a key, cool. Useless for now.";
        isConsumable = true;
        isCombinable = true;
        itemCombinationName = "Blade of a Key";
        itemToGive = new GreyKey();
    }
}
