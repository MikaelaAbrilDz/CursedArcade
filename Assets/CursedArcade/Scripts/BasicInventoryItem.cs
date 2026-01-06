using UnityEngine;

public class BasicInventoryItem : MonoBehaviour
{
    public string itemName;
    public string itemStat;
    public int itemStatAmount;
    public virtual void ItemToInventory(Inventory inv)
    {

    }
    public virtual void ItemToCharacter(CharacterOnGround character)
    {

    }
}
