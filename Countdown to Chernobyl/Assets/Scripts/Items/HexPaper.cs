using UnityEngine;

public class HexPaper : Item
{
    public HexPaper()
    {
        icon = Resources.Load<Sprite>("Icons/HexPaper");
        itemName = "Hexidecimal Paper";
        descriptionEasy = "A paper with the text \"1B7C.\" It looks like hexidecimal? So if A = 10...";
        descriptionMedium = "A sheet of paper with the text \"1B7C.\" I think it's supposed to be a different number system?";
        descriptionHard = "A sheet of paper with the text \"1B7C.\" Where in the world have I seen numbers used with letters?";
        isConsumable = false;
        isCombinable = false;
        itemCombinationName = null;
        itemToGive = null;
    }
}
