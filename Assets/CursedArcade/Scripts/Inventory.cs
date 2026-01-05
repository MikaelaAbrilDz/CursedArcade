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
    public void AddHelmet(int helmetValue)
    {
        PlayerController player = GetComponent<PlayerController>();
        if (player.stats.lifeMaxBase - player.stats._lifeMax < helmetValue) player.stats._lifeMax = player.stats.lifeMaxBase + helmetValue;
    }
    public void AddBoots(int bootsValue)
    {
        PlayerController player = GetComponent<PlayerController>();
        if (player.stats.speedBase - player.stats._speed < bootsValue) player.stats._speed = player.stats.speedBase + bootsValue;
    }
}
