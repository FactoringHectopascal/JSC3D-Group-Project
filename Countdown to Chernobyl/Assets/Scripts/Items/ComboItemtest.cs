

public class ComboItemTest : Item
{
    public ComboItemTest()
    {
        itemName = "Combo Item";
        descriptionEasy = "Item used for testing the item combination system";
        descriptionMedium = "This might go to something.";
        descriptionHard = "I definitely can't do something just with this.";
        isConsumable = false;
        isCombinable = true;
        itemCombinationName = "Combo Item 2";
        itemToGive = new TestKey();
    }
}
