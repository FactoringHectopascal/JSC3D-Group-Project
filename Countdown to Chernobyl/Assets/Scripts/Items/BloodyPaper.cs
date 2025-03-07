using UnityEngine;

public class BloodyPaper : Item
{
    public BloodyPaper()
    {
        icon = icon = Resources.Load<Sprite>("Icons/BloodyPaper");
        itemName = "Bloody Paper";
        descriptionEasy = "It's a piece of paper, it's got the numbers two and one written on it. It's weird though, is it written in blood?";
        descriptionMedium = "A sheet of paper, it's got the numbers two and one written on it. This is freaking me out though, why is it written in what looks like old blood?";
        descriptionHard = "Umm.. It's a sheet of paper with the numbers two and one on it.. What is this written in?";
        isConsumable = false;
        isCombinable = true;
        itemCombinationName = "Luminol";
        itemToGive = new LuminolPaper();
    }
}
