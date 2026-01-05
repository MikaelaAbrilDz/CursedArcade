using TMPro;
using UnityEngine;

public class BootsEntity : BasicInventoryItem
{
    [SerializeField] int speedAdditionBase, speedAdditionDesviation;
    private int speedAddition = 0;
    private void Start()
    {
        speedAddition = CalculateSpeedAddition();
    }
    private int CalculateSpeedAddition()
    {
        return (int)Mathf.Max((speedAdditionBase + speedAdditionDesviation * Mathf.Sqrt(-2f * Mathf.Log(Random.value)) * Mathf.Cos(2f * Mathf.PI * Random.value)), 1);
    }
    public override void ItemToInventory(Inventory inv)
    {
        inv.AddBoots(speedAddition);
    }
    public override void ItemToCharacter(CharacterOnGround character)
    {
        if (character.stats._speed - character.stats.speedBase < speedAddition) character.stats._speed = character.stats.speedBase + speedAddition;
    }
}
