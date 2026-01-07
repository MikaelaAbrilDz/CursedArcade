using UnityEngine;
using TMPro; 

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float lifeTime = 0.7f;
    [SerializeField] private float floatHeight = 1f;

    private float timer;
    private TextMeshProUGUI tmpText; 

    private void Awake()
    {
        tmpText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Setup(int damage)
    {
        if (tmpText != null)
        {
            tmpText.text = damage.ToString();
        }
    }

    private void Update()
    {
        // Mover hacia arriba
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        // Contar tiempo y destruir pa q desaparezca
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
