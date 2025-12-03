using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterOnGround
{
    public void OnMovementUp(InputAction.CallbackContext context)
    {

        if (turnManager.turnList[0] == GetComponent<CharacterOnGround>() && context.performed)
        {
            Move(0);
        }
    }

    public void OnMovementRight(InputAction.CallbackContext context)
    {

        if (turnManager.turnList[0] == GetComponent<CharacterOnGround>() && context.performed)
        {
            Move(1);
        }
    }

    public void OnMovementDown(InputAction.CallbackContext context)
    {

        if (turnManager.turnList[0] == GetComponent<CharacterOnGround>() && context.performed)
        {
            Move(2);
        }
    }

    public void OnMovementLeft(InputAction.CallbackContext context)
    {

        if (turnManager.turnList[0] == GetComponent<CharacterOnGround>() && context.performed)
        {
            Move(3);
        }
    }

    public void OnHeal(InputAction.CallbackContext context)
    {
        if (context.started && GetComponent<Inventory>()._healthKits > 0)
        {
            GetComponent<CharacterStats>()._life += 20;
            GetComponent<Inventory>()._healthKits--;
        }
    }
}

