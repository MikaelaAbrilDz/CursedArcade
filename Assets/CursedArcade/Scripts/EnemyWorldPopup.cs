using TMPro;
using UnityEngine;

public class EnemyWorldPopup : MonoBehaviour
{
    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private TextMeshPro speedText;
    [SerializeField] private TextMeshPro attackText;

    public void Setup(CharacterStats stats)
    {
        nameText.text = stats.CharacterName;
        speedText.text = "Velocidad: " + stats.Speed;
        attackText.text = "Ataque: " + stats.Attack;
    }
}
