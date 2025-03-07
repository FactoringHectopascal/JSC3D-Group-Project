using UnityEngine;

public class LuminolPaper : Item
{
    public LuminolPaper()
    {

        icon = icon = Resources.Load<Sprite>("Icons/LuminolPaper");
        itemName = "Bloody Paper with Luminol";
        descriptionEasy = "It's a piece of paper with the numbers two and one writ in what looks like blood. The luminol activated with the paper and now there's a seven too.";
        descriptionMedium = "A sheet of paper, it's got the numbers two and one written on it. The luminol activated with it, and now there's a glowing seven.";
        descriptionHard = "A sheet of paper, it's got the numbers two and one, and now seven thanks to the luminol.";
        isConsumable = false;
        isCombinable = false;
        itemCombinationName = null;
        itemToGive = null;
    }
}
