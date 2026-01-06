using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemHover : MonoBehaviour
{
    [SerializeField] private GameObject popupPrefab;

    private IItemPopupInfo info;
    private GameObject popupInstance;

    private void Awake()
    {
        info = GetComponent<IItemPopupInfo>();
    }

    private void OnMouseEnter()
    {
        if (popupPrefab == null || info == null) return;

        Vector3 pos = transform.position + Vector3.up * 2f;
        popupInstance = Instantiate(popupPrefab, pos, Quaternion.identity);

        ItemWorldPopup popup = popupInstance.GetComponent<ItemWorldPopup>();
        if (popup != null)
        {
            popup.Setup(info);
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
