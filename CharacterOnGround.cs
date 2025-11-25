using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterOnGround : BasicEntity
{
    protected TurnManager turnManager;
    bool isMoving = false;
    public Animator anim;
    private void Start()
    {
        turnManager = FindAnyObjectByType<TurnManager>();

        anim = GetComponentInChildren<Animator>();
    }
    protected bool Move(int directionIndex)
    {
        if (isMoving || CurrentChecker().sideCheckers[directionIndex] == null || CurrentChecker().sideCheckers[directionIndex].positioned != null &&
            CurrentChecker().sideCheckers[directionIndex].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) return false;
        isMoving = true;
        anim.SetBool("isWalking", true);

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

        Checker current = CurrentChecker();
        if (current != null && current.positioned != null)
        {
            // Si hay un punch en esta casilla
            PunchEntity punch = current.positioned as PunchEntity;
            if (punch != null)
            {
                punch.PickUp(this);
            }
            HealthKitEntity hk = current.positioned as HealthKitEntity;
            if (hk != null)
            {
                hk.PickUp(this);
            }
            // Aquí puedes seguir añadiendo otros tipos (HealthKitEntity, etc.)
        }

        turnManager.PassTurn(this);
        isMoving = false;
        anim.SetBool("isWalking", false);
    }

    public virtual void StartTurn()
    {

    }
}
