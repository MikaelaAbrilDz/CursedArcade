using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private Inventory inventory;

    [Header("Textos UI")]
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI healthKitsText;
    [SerializeField] private TextMeshProUGUI healthText;       

    void Update()
    {
        UpdateStats();
        UpdateInventory();
    }

    private void UpdateStats()
    {
        if (characterStats == null) return;

        speedText.text = "Velocidad: " + characterStats._speed;
        attackText.text = "Ataque: " + characterStats._attack;
        healthText.text = characterStats._life + "/" + characterStats._lifeMax;
    }

    private void UpdateInventory()
    {
        if (inventory == null) return;

        healthKitsText.text = "x " + inventory._healthKits;
    }
}