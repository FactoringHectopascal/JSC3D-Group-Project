using UnityEngine;

public class RuminolBottle : Item
{
    public RuminolBottle()
    {
        icon = icon = Resources.Load<Sprite>("Icons/Luminol");
        itemName = "Luminol";
        descriptionEasy = "It's a bottle that says \"Luminol\" on it. I think I've seen this on Police TV? Yeah! When it comes into contact with trace amounts of blood, it starts glowing blue. It's useful for forensic teams at crime scenes. But, why would that be useful here?";
        descriptionMedium = "A bottle that reads \"Luminol\" on the label. I believe I've seen this used before in forensic science, something to do with blood. I forget what it is though. Aghh.. What's it doing here?";
        descriptionHard = "A bottle that contains Luminol, I'm not entirely sure what that is. Though, I'm led to believe I'm supposed to spray this somewhere, maybe then it'll light my path?";
        isConsumable = false;
        isCombinable = true;
        itemCombinationName = "Bloody Paper";
        itemToGive = new LuminolPaper();
    }
}
