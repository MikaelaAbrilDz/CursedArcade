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
    public void OnAtack_0(InputAction.CallbackContext context)
    {
        if (context.performed && !isAtacking)
        {
            CharacterOnGround target = null;
            float angle = transform.eulerAngles.y;
            if (angle < 0) angle += 360;
            
            switch (angle)
            {
                case 0:
                    if (CurrentChecker().sideCheckers[0] != null && CurrentChecker().sideCheckers[0].positioned != null) target = (CharacterOnGround)CurrentChecker().sideCheckers[0].positioned;
                    break;
                case 90:
                    if (CurrentChecker().sideCheckers[1] != null && CurrentChecker().sideCheckers[1].positioned != null) target = (CharacterOnGround)CurrentChecker().sideCheckers[1].positioned;
                    break;
                case 180:
                    if (CurrentChecker().sideCheckers[2] != null && CurrentChecker().sideCheckers[2].positioned != null) target = (CharacterOnGround)CurrentChecker().sideCheckers[2].positioned;
                    break;
                case 270:
                    if (CurrentChecker().sideCheckers[3] != null && CurrentChecker().sideCheckers[3].positioned != null) target = (CharacterOnGround)CurrentChecker().sideCheckers[3].positioned;
                    break;
            }
            StartCoroutine(AtackCo(stats._attack, 2, 1.2f, 2, target, 0.7f, "Punch"));
        }
    }
}

