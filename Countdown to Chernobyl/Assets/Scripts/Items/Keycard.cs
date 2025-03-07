
using UnityEngine;

public class Keycard : Item
{
    public Keycard()
    {
        icon = icon = Resources.Load<Sprite>("Icons/Keycard");
        itemName = "Keycard";
        descriptionEasy = "A keycard! I wonder whose this is? Anyways, I can unequip it by hitting the minus symbol. I can also close the item menu by hitting G again.";
        descriptionMedium = "A keycard! I wonder whose this is? Anyways, I can unequip it by hitting the minus symbol. I can also close the item menu by hitting G again.";
        descriptionHard = "A keycard! I wonder whose this is? Anyways, I can unequip it by hitting the minus symbol. I can also close the item menu by hitting G again.";
        isConsumable = true;
        isCombinable = false;
        itemCombinationName = null;
        itemToGive = null;
    }
}
