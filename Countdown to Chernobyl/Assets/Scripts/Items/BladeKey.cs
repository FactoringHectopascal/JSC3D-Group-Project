using UnityEngine;

public class BladeKey : Item
{   public BladeKey()
    {
        icon = Resources.Load<Sprite>("Icons/KeyGreyTip");
        itemName = "Blade of a Key";
        descriptionEasy = "This is the blade of a key, if I can find the bow I can attach this to it.";
        descriptionMedium = "The part of a key you put into the lock, if only I could attach it to something.";
        descriptionHard = "The end of a key, useless without the beginning. It's all about the journey.";
        isConsumable = true;
        isCombinable = true;
        itemCombinationName = "Bow of a Key";
        itemToGive = new GreyKey();
    }
}
