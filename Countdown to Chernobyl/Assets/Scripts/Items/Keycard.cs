using JetBrains.Annotations;
using UnityEngine;

public class Keycard : Item
{
    public Keycard()
    {
        icon = icon = Resources.Load<Sprite>("Icons/Keycard");
        itemName = "Keycard";
        descriptionEasy = "My keycard! I can use this to open the door to the control room.";
        descriptionMedium = "This looks like my keycard. I can use this.";
        descriptionHard = "A keycard, I think it's mine.";
        isConsumable = true;
        isCombinable = false;
        itemCombinationName = null;
        itemToGive = null;
    }
}
