using UnityEngine;
using System.Collections.Generic;
using UnityEngine.TextCore.Text;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int healthKits = 0;   // Empiezas sin kits

    public int _healthKits
    {
        get => healthKits;
        set => healthKits = value;
    }

    public void AddHealthKit()
    {
        _healthKits += 1;
    }
    public void AddPunch(int punchValue)
    {
        PlayerController player = GetComponent<PlayerController>();
        if (player.stats.attackBase - player.stats._attack < punchValue) player.stats._attack = player.stats.attackBase + punchValue;
    }
}
