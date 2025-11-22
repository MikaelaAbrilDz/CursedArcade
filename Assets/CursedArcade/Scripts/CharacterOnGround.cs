using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterOnGround : BasicEntity
{
    protected TurnManager turnManager;
    bool isMoving = false;
    private void Start()
    {
        turnManager = FindAnyObjectByType<TurnManager>();
    }
    protected bool Move(int directionIndex)
    {
        if (isMoving || CurrentChecker().sideCheckers[directionIndex] == null || CurrentChecker().sideCheckers[directionIndex].positioned != null &&
            CurrentChecker().sideCheckers[directionIndex].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) return false;
        isMoving = true;


        switch (directionIndex)
        {
            case 0:
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                break;

            case 1:
                transform.eulerAngles = new Vector3(0f, 90f, 0f);
                break;

            case 2:
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                break;

                case 3:
                transform.eulerAngles = new Vector3(0f, 270f, 0f);
                break;
        }


        SetPositionedChecker(false);
        LeanTween.move(gameObject, CurrentChecker().sideCheckers[directionIndex].transform.position, 0.2f)
            .setEaseOutQuad().setOnComplete(()=>FinishMovement());
        return true;
    }
    private void FinishMovement()
    {
        SetPositionedChecker(true);
        turnManager.PassTurn(this);
        isMoving = false;
    }
    public virtual void StartTurn()
    {

    }
}
