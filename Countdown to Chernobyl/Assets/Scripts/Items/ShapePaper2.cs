using UnityEngine;

public class ShapePaper2 : Item
{
    public ShapePaper2()
    {
        icon = Resources.Load<Sprite>("Icons/ShapePaper2");
        itemName = "Second paper with shapes.";
        descriptionEasy = "A paper with a triangle and a square, it's labeled \"2.\" What can I gather from the elements of a pair of shapes?";
        descriptionMedium = "A paper labeled \"2\" with a triangle and a square. What kind of info would some shapes give me?";
        descriptionHard = "A paper with a triangle and a square, the second of its kind.";
        isConsumable = false;
        isCombinable = false;
        itemCombinationName = null;
        itemToGive = null;
    }
}
