using UnityEngine;

public class EnemyHover : MonoBehaviour
{
    private CharacterStats stats;
    private GameObject popupInstance;

    [SerializeField] private GameObject popupPrefab;

    private void Awake()
    {
        stats = GetComponentInParent<CharacterStats>();
    }

    private void OnMouseEnter()
    {
        if (popupInstance == null)
        {
            Vector3 pos = transform.position + Vector3.up * 2f;
            popupInstance = Instantiate(popupPrefab, pos, Quaternion.identity);
            popupInstance.GetComponent<EnemyWorldPopup>().Setup(stats);
        }
    }

    private void OnMouseExit()
    {
        if (popupInstance != null)
        {
            Destroy(popupInstance);
        }
    }
}
