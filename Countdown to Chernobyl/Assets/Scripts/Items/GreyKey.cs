using UnityEngine;

public class GreyKey : Item
{
    public GreyKey()
    {
        icon = Resources.Load<Sprite>("Icons/KeyGrey");
        itemName = "Grey Key";
        descriptionEasy = "A whole key! Now I can use this on a lock!";
        descriptionMedium = "All together now! I can use this key now.";
        descriptionHard = "How many people can say they put a key together with their bare hands?";
        isConsumable = true;
        isCombinable = false;
        itemCombinationName = null;
        itemToGive = null;
    }
}
