using UnityEngine;

public class ShapePaper1 : Item
{
    public ShapePaper1()
    {
        icon = Resources.Load<Sprite>("Icons/ShapePaper1");
        itemName = "First paper with shapes.";
        descriptionEasy = "A paper with a circle and a square from left to right. It's labeled \"1.\" What can I gather from the elements of a pair of shapes?";
        descriptionMedium = "A paper labeled \"1\" with a circle and a square. What kind of info would some shapes give me?";
        descriptionHard = "A paper with a circle and a square, the first of its kind.";
        isConsumable = false;
        isCombinable = false;
        itemCombinationName = null;
        itemToGive = null;
    }
}
