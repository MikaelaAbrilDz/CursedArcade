using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemHover : MonoBehaviour
{
    [SerializeField] private GameObject popupPrefab;
    [SerializeField] Transform pos;

    private ItemOnGround item;
    private GameObject popupInstance;

    private void Awake()
    {
        item = GetComponent<ItemOnGround>();
    }

    private void OnMouseEnter()
    {
        if (popupPrefab == null || item == null) return;

        popupInstance = Instantiate(popupPrefab, pos.position, Quaternion.identity);

        ItemWorldPopup popup = popupInstance.GetComponent<ItemWorldPopup>();
        if (popup != null)
        {
            popup.Setup(item.item.itemName, item.item.itemStat, item.item.itemStatAmount);
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
