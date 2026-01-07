using UnityEngine;

public class HealthKitEntity : BasicInventoryItem
{
    
    private int amountToHeal;
    private void Awake()
    {
        itemName = "Botiquín";
        itemStat = "Curación";
        itemStatAmount = amountToHeal;
    }
    public override void ItemToInventory(Inventory inv)
    {
        inv.AddHealthKit();
    }
    public override void ItemToCharacter(CharacterOnGround character)
    {
        character.stats._life += amountToHeal;
    }
}
