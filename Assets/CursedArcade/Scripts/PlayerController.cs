using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharactersOnGround
{
    public void OnMovementUp(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<CharactersOnGround>() && context.performed)
        {
            transform.position = CurrentChecker().sideCheckers[0].transform.position;
            turnManager.PassTurn(GetComponent<CharactersOnGround>());
        }
    }
    public void OnMovementRight(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<CharactersOnGround>() && context.performed)
        {
            transform.position = CurrentChecker().sideCheckers[1].transform.position;
            turnManager.PassTurn(GetComponent<CharactersOnGround>());
        }
    }
    public void OnMovementDown(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<CharactersOnGround>() && context.performed)
        {
            transform.position = CurrentChecker().sideCheckers[2].transform.position;
            turnManager.PassTurn(GetComponent<CharactersOnGround>());
        }
    }
    public void OnMovementLeft(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<CharactersOnGround>() && context.performed)
        {
            transform.position = CurrentChecker().sideCheckers[3].transform.position;
            turnManager.PassTurn(GetComponent<CharactersOnGround>());
        }
    }


    public void OnHeal(InputAction.CallbackContext context)
    {
        if (context.started && GetComponent<Inventory>()._healthKits > 0)
        {
            GetComponent<PlayerStats>()._life += 20;
        }
    }
}
