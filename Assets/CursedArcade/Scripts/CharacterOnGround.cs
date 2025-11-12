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
    protected void Move(int directionIndex)
    {
        if (isMoving || CurrentChecker().sideCheckers[directionIndex] == null) return;
        isMoving = true;
        SetPositionedChecker(false);
        LeanTween.move(gameObject, CurrentChecker().sideCheckers[directionIndex].transform.position, 0.2f)
            .setEaseOutQuad().setOnComplete(()=>FinishMovement());
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
