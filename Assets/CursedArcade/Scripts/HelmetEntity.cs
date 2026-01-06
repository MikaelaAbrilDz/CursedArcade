using TMPro;
using UnityEngine;

public class HelmetEntity : BasicInventoryItem, IItemPopupInfo
{

    [SerializeField] int lifeAdditionBase, lifeAdditionDesviation;
    private int lifeAddition = 0;

    public string ItemName => "Casco";
    public string StatName => "Vida máxima";
    public int Amount => lifeAddition;


    private void Start()
    {
        lifeAddition = CalculateLifeAddition();
    }
    private int CalculateLifeAddition()
    {
        return (int)(lifeAdditionBase + lifeAdditionDesviation * Mathf.Sqrt(-2f * Mathf.Log(Random.value)) * Mathf.Cos(2f * Mathf.PI * Random.value));
    }
    public override void ItemToInventory(Inventory inv)
    {
        inv.AddHelmet(lifeAddition);
    }
    public override void ItemToCharacter(CharacterOnGround character)
    {
        if (character.stats._lifeMax - character.stats.lifeMaxBase < lifeAddition) character.stats._lifeMax = character.stats.lifeMaxBase + lifeAddition;
    }
}
