using UnityEngine;

public class HealthKitEntity : BasicInventoryItem
{
    [SerializeField] int ammountToHeal;
    public override void ItemToInventory(Inventory inv)
    {
        inv.AddHealthKit();
    }
    public override void ItemToCharacter(CharacterOnGround character)
    {
        character.stats._life += ammountToHeal;
    }
}
