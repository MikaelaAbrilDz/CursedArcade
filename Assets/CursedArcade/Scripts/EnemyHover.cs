using UnityEngine;

public class EnemyHover : MonoBehaviour
{
    private CharacterStats stats;
    private GameObject popupInstance;

    [SerializeField] Transform pos;

    [SerializeField] private GameObject popupPrefab;

    private void Awake()
    {
        stats = GetComponent<CharacterStats>();
    }

    private void OnMouseEnter()
    {
        if (popupInstance == null)
        {
            popupInstance = Instantiate(popupPrefab, pos.position, Quaternion.identity);
            popupInstance.GetComponent<EnemyWorldPopup>().Setup(stats);
        }
    }

    private void OnMouseExit()
    {
        DestroyPopup();
    }
    public void DestroyPopup()
    {
        if (popupInstance != null)
        {
            Destroy(popupInstance);
        }
    }
}
