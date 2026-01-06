using UnityEngine;
using TMPro;

public class ItemWorldPopup : MonoBehaviour
{
    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private TextMeshPro statText;

    public void Setup(string itemName, string statName, int amount)
    {
        nameText.text = itemName;
        statText.text = statName + ": +" + amount;
    }
}
