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
            GetComponent<CharacterStats>()._life += 25;
            GetComponent<Inventory>()._healthKits--;
        }
    }
    public void OnAtack_0(InputAction.CallbackContext context)
    {
        if (turnManager.turnList[0] == GetComponent<CharacterOnGround>() && context.performed && !isAtacking)
        {
            CharacterOnGround target = null;
            float angle = transform.eulerAngles.y;
            if (angle < 0) angle += 360;
            
            switch (angle)
            {
                case 0:
                    if (CurrentChecker().sideCheckers[0] != null && CurrentChecker().sideCheckers[0].positioned != null && 
                        CurrentChecker().sideCheckers[0].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) target = (CharacterOnGround)CurrentChecker().sideCheckers[0].positioned;
                    break;
                case 90:
                    if (CurrentChecker().sideCheckers[1] != null && CurrentChecker().sideCheckers[1].positioned != null &&
                        CurrentChecker().sideCheckers[1].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) target = (CharacterOnGround)CurrentChecker().sideCheckers[1].positioned;
                    break;
                case 180:
                    if (CurrentChecker().sideCheckers[2] != null && CurrentChecker().sideCheckers[2].positioned != null && 
                        CurrentChecker().sideCheckers[2].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) target = (CharacterOnGround)CurrentChecker().sideCheckers[2].positioned;
                    break;
                case 270:
                    if (CurrentChecker().sideCheckers[3] != null && CurrentChecker().sideCheckers[3].positioned != null && 
                        CurrentChecker().sideCheckers[3].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) target = (CharacterOnGround)CurrentChecker().sideCheckers[3].positioned;
                    break;
            }
            Atack(stats._attack, 2, 1.2f, 2, target, 0.55f, "Punch");
        }
    }
    public void OnAtack_1(InputAction.CallbackContext context)
    {
        if (turnManager.turnList[0] == GetComponent<CharacterOnGround>() && context.performed && !isAtacking)
        {
            CharacterOnGround[] target = new CharacterOnGround[8];

            if (CurrentChecker().sideCheckers[0] != null && CurrentChecker().sideCheckers[0].positioned != null && 
                CurrentChecker().sideCheckers[0].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) target[0] = (CharacterOnGround)CurrentChecker().sideCheckers[0].positioned;
            if (CurrentChecker().sideCheckers[1] != null && CurrentChecker().sideCheckers[1].positioned != null && 
                CurrentChecker().sideCheckers[1].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) target[1] = (CharacterOnGround)CurrentChecker().sideCheckers[1].positioned;
            if (CurrentChecker().sideCheckers[2] != null && CurrentChecker().sideCheckers[2].positioned != null && 
                CurrentChecker().sideCheckers[2].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) target[2] = (CharacterOnGround)CurrentChecker().sideCheckers[2].positioned;
            if (CurrentChecker().sideCheckers[3] != null && CurrentChecker().sideCheckers[3].positioned != null && 
                CurrentChecker().sideCheckers[3].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) target[3] = (CharacterOnGround)CurrentChecker().sideCheckers[3].positioned;

            if (CurrentChecker().sideCheckers[0] != null && CurrentChecker().sideCheckers[0].sideCheckers[1] != null && CurrentChecker().sideCheckers[0].sideCheckers[1].positioned != null &&
                CurrentChecker().sideCheckers[0].sideCheckers[1].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround)))
            {
                target[4] = (CharacterOnGround)CurrentChecker().sideCheckers[0].sideCheckers[1].positioned;
            }
            else if (CurrentChecker().sideCheckers[1] != null && CurrentChecker().sideCheckers[1].sideCheckers[0] != null && CurrentChecker().sideCheckers[1].sideCheckers[0].positioned != null && 
                CurrentChecker().sideCheckers[1].sideCheckers[0].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround)))
            {
                target[4] = (CharacterOnGround)CurrentChecker().sideCheckers[1].sideCheckers[0].positioned;
            }

            if (CurrentChecker().sideCheckers[1] != null && CurrentChecker().sideCheckers[1].sideCheckers[2] != null && CurrentChecker().sideCheckers[1].sideCheckers[2].positioned != null &&
                CurrentChecker().sideCheckers[1].sideCheckers[2].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround)))
            {
                target[5] = (CharacterOnGround)CurrentChecker().sideCheckers[1].sideCheckers[2].positioned;
            }
            else if (CurrentChecker().sideCheckers[2] != null && CurrentChecker().sideCheckers[2].sideCheckers[1] != null && CurrentChecker().sideCheckers[2].sideCheckers[1].positioned != null &&
                CurrentChecker().sideCheckers[2].sideCheckers[1].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround)))
            {
                target[5] = (CharacterOnGround)CurrentChecker().sideCheckers[2].sideCheckers[1].positioned;
            }

            if (CurrentChecker().sideCheckers[2] != null && CurrentChecker().sideCheckers[2].sideCheckers[3] != null && CurrentChecker().sideCheckers[2].sideCheckers[3].positioned != null &&
                CurrentChecker().sideCheckers[2].sideCheckers[3].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround)))
            {
                target[6] = (CharacterOnGround)CurrentChecker().sideCheckers[2].sideCheckers[3].positioned;
            }
            else if (CurrentChecker().sideCheckers[3] != null && CurrentChecker().sideCheckers[3].sideCheckers[2] != null && CurrentChecker().sideCheckers[3].sideCheckers[2].positioned != null &&
                CurrentChecker().sideCheckers[3].sideCheckers[2].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround)))
            {
                target[6] = (CharacterOnGround)CurrentChecker().sideCheckers[3].sideCheckers[2].positioned;
            }

            if (CurrentChecker().sideCheckers[3] != null && CurrentChecker().sideCheckers[3].sideCheckers[0] != null && CurrentChecker().sideCheckers[3].sideCheckers[0].positioned != null &&
                CurrentChecker().sideCheckers[3].sideCheckers[0].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround)))
            {
                target[7] = (CharacterOnGround)CurrentChecker().sideCheckers[3].sideCheckers[0].positioned;
            }
            else if (CurrentChecker().sideCheckers[0] != null && CurrentChecker().sideCheckers[0].sideCheckers[3] != null && CurrentChecker().sideCheckers[0].sideCheckers[3].positioned != null &&
                CurrentChecker().sideCheckers[0].sideCheckers[3].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround)))
            {
                target[7] = (CharacterOnGround)CurrentChecker().sideCheckers[0].sideCheckers[3].positioned;
            }


            Atack(stats._attack, 2, 1.2f, 1, target, 0.7f, "Punch2");
        }
    }
}

