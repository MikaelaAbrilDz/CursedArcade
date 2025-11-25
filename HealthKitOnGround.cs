using UnityEngine;

public class HealthKitOnGround : MonoBehaviour
{
    [SerializeField] private int amount = 1; // Cuántos kits añade

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró en el trigger con: " + other.name);
        if (!other.CompareTag("Player")) return;

        Inventory inv = other.GetComponent<Inventory>();
        if (inv == null) return;

        // Añade al inventario
        inv.AddHealthKits(amount);

        // Si quieres también meterlo en la lista de items (si tu ObjectOnGround tiene objectName = "HealthKit")
        ObjectOnGround obj = GetComponent<ObjectOnGround>();
        if (obj != null)
        {
            inv.AddItem(obj);
        }

        // Destruye el objeto del suelo
        Destroy(gameObject);
    }
}

