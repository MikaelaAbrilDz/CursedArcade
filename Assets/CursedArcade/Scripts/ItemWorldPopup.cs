using UnityEngine;
using TMPro;

public class ItemWorldPopup : MonoBehaviour
{
    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private TextMeshPro statText;

    public void Setup(IItemPopupInfo info)
    {
        nameText.text = info.ItemName;
        statText.text = info.StatName + ": +" + info.Amount;
    }
}
