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
        if (player.stats._attack - player.stats.attackBase < punchValue) player.stats._attack = player.stats.attackBase + punchValue;
    }
    public void AddHelmet(int helmetValue)
    {
        PlayerController player = GetComponent<PlayerController>();
        if (player.stats._lifeMax - player.stats.lifeMaxBase < helmetValue)
        {
            float percentageOfLife = Mathf.InverseLerp(0, player.stats._lifeMax, player.stats._life);

            player.stats._lifeMax = player.stats.lifeMaxBase + helmetValue;

            player.stats._life = (int)(player.stats._lifeMax * percentageOfLife);
        }
    }
    public void AddBoots(int bootsValue)
    {
        PlayerController player = GetComponent<PlayerController>();
        if (player.stats._speed - player.stats.speedBase < bootsValue) player.stats._speed = player.stats.speedBase + bootsValue;
    }
}
