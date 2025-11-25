using UnityEngine;

public class HealthKitEntity : BasicEntity
{
    [SerializeField] private int amount = 1;

    // Llama a esto cuando un CharacterOnGround entra en la misma casilla
    public void PickUp(CharacterOnGround character)
    {
        Inventory inv = character.GetComponent<Inventory>();
        if (inv == null) return;

        inv.AddHealthKits(amount);

        // Opcional: añadir a lista de items
        ObjectOnGround obj = GetComponent<ObjectOnGround>();
        if (obj != null)
        {
            inv.AddItem(obj);
        }

        // Liberar la casilla
        SetPositionedChecker(false);

        // Destruir el objeto del suelo
        Destroy(gameObject);
    }
}
