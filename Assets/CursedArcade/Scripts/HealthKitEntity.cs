using UnityEngine;

public class HealthKitEntity : BasicInventoryItem, IItemPopupInfo
{
    
    private int amountToHeal;

    public string ItemName => "Botiquín"; 
    public string StatName => "Vida"; 
    public int Amount => amountToHeal;
    public override void ItemToInventory(Inventory inv)
    {
        inv.AddHealthKit();
    }
    public override void ItemToCharacter(CharacterOnGround character)
    {
        character.stats._life += amountToHeal;
    }
}
