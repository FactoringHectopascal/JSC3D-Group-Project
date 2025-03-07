
public class ComboItem2 : Item
{
    public ComboItem2()
    {
        itemName = "Combo Item 2";
        descriptionEasy = "Item used for testing the item combination system, the second part to the whole.";
        descriptionMedium = "This might go to something.";
        descriptionHard = "I definitely can't do something just with this.";
        isConsumable = false;
        isCombinable = true;
        itemCombinationName = "Combo Item";
        itemToGive = new TestKey();
    }
}
