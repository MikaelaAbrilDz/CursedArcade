using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterOnGround
{
    public void OnMovementUp(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<CharacterOnGround>() && context.performed)
        {
            Move(0);
            turnManager.PassTurn(GetComponent<CharacterOnGround>());
        }
    }

    public void OnMovementRight(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<CharacterOnGround>() && context.performed)
        {
            Move(1);
            turnManager.PassTurn(GetComponent<CharacterOnGround>());
        }
    }

    public void OnMovementDown(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<CharacterOnGround>() && context.performed)
        {
            Move(2);
            turnManager.PassTurn(GetComponent<CharacterOnGround>());
        }
    }

    public void OnMovementLeft(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<CharacterOnGround>() && context.performed)
        {
            Move(3);
            turnManager.PassTurn(GetComponent<CharacterOnGround>());
        }
    }

    public void OnHeal(InputAction.CallbackContext context)
    {
        if (context.started && GetComponent<Inventory>()._healthKits > 0)
        {
            GetComponent<PlayerStats>()._life += 20;
            GetComponent<Inventory>()._healthKits--;
        }
    }
}

