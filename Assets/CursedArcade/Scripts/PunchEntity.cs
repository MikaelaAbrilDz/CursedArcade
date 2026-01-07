using TMPro;
using UnityEngine;

public class PunchEntity : BasicInventoryItem
{
    [SerializeField] int attackAdditionBase, attackAdditionDesviation;
    private int attackAddition = 0;


    private void Start()
    {
        attackAddition = CalculateAttackAddition();

        itemStat = "Ataque";
        itemStatAmount = attackAddition;
    }
    private int CalculateAttackAddition()
    {
        return (int)(attackAdditionBase + attackAdditionDesviation * Mathf.Sqrt(-2f * Mathf.Log(Random.value)) * Mathf.Cos(2f * Mathf.PI * Random.value));
    }
    public override void ItemToInventory(Inventory inv)
    {
        inv.AddPunch(attackAddition);
    }
    public override void ItemToCharacter(CharacterOnGround character)
    {
        if (character.stats._attack - character.stats.attackBase < attackAddition) character.stats._attack = character.stats.attackBase + attackAddition;
    }
}
