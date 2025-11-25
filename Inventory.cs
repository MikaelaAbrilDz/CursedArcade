using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<ObjectOnGround> items = new List<ObjectOnGround>();

    [SerializeField] private int healthKits = 0;   // Empiezas sin kits

    public int _healthKits
    {
        get => healthKits;
        set => healthKits = value;
    }

    public void AddHealthKits(int amount)
    {
        healthKits += amount;
    }
    public void AddItem(ObjectOnGround item)
    {
        items.Add(item);
    }

    public void RemoveItem(ObjectOnGround item)
    {
        items.Remove(item);
    }

    public bool HasItem(string name)
    {
        return items.Exists(i => i.objectName == name);
    }
}
