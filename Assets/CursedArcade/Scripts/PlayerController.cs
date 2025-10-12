using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BasicEntity
{
    public void OnMovementUp(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<BasicEntity>() && context.performed)
        {
            transform.position = CurrentChecker().sideCheckers[0].transform.position;
            turnManager.PassTurn(GetComponent<BasicEntity>());
        }
    }
    public void OnMovementRight(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<BasicEntity>() && context.performed)
        {
            transform.position = CurrentChecker().sideCheckers[1].transform.position;
            turnManager.PassTurn(GetComponent<BasicEntity>());
        }
    }
    public void OnMovementDown(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<BasicEntity>() && context.performed)
        {
            transform.position = CurrentChecker().sideCheckers[2].transform.position;
            turnManager.PassTurn(GetComponent<BasicEntity>());
        }
    }
    public void OnMovementLeft(InputAction.CallbackContext context)
    {
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();

        if (turnManager.turnList[0] == GetComponent<BasicEntity>() && context.performed)
        {
            transform.position = CurrentChecker().sideCheckers[3].transform.position;
            turnManager.PassTurn(GetComponent<BasicEntity>());
        }
    }
}
