using UnityEngine;

public class PunchEntity : BasicEntity
{
    [SerializeField] private float attackMultiplierPerPunch = 0.2f; // +20% por punch, por ejemplo

    public void PickUp(CharacterOnGround character)
    {
        Inventory inv = character.GetComponent<Inventory>();
        if (inv == null) return;

        // Guardar el objeto en el inventario
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

    public float GetMultiplierPerPunch()
    {
        return attackMultiplierPerPunch;
    }
}
