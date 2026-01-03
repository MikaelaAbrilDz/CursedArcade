using UnityEngine;

public class ItemOnGround : BasicEntity
{
    [SerializeField] BasicInventoryItem item;

    // Llama a esto cuando un CharacterOnGround entra en la misma casilla
    public void PickUp(CharacterOnGround character)
    {
        Inventory inv = character.GetComponent<Inventory>();

        if (inv != null)
        {
            item.ItemToInventory(inv);
        }
        else
        {
            item.ItemToCharacter(character);
        }


        // Liberar la casilla
        SetPositionedChecker(false);

        // Destruir el objeto del suelo
        Destroy(gameObject);
    }
}
