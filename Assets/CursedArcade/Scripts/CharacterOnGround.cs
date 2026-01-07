using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class CharacterOnGround : BasicEntity
{
    protected TurnManager turnManager;
    protected bool isMoving = false, isAtacking = false;
    public Animator anim;
    public CharacterStats stats;
    private int actionsLeft;
    private void Start()
    {
        turnManager = FindAnyObjectByType<TurnManager>();

        anim = GetComponentInChildren<Animator>();

        stats = GetComponent<CharacterStats>();
    }
    protected bool Move(int directionIndex)
    {
        if (isAtacking) return false;

        LookToIndex(directionIndex);

        if (isMoving || CurrentChecker().sideCheckers[directionIndex] == null || CurrentChecker().sideCheckers[directionIndex].positioned != null &&
            CurrentChecker().sideCheckers[directionIndex].positioned.GetType().IsSubclassOf(typeof(CharacterOnGround))) return false;
        isMoving = true;
        anim.SetBool("isWalking", true);



        SetPositionedChecker(false);
        LeanTween.move(gameObject, CurrentChecker().sideCheckers[directionIndex].transform.position, 0.2f)
            .setEaseOutQuad().setOnComplete(()=>FinishMovement());
        return true;
    }
    private void FinishMovement()
    {
        Checker current = CurrentChecker();
        if (current.positioned != null && current.positioned.GetComponent<ItemOnGround>() != null)
        {
            current.positioned.GetComponent<ItemOnGround>().PickUp(this);
        }

        SetPositionedChecker(true);

        anim.SetBool("isWalking", false);
        EndAction();
        isMoving = false;
    }
    public virtual void StartTurn()
    {

    }
    public void SetActionsForTurn()
    {
        actionsLeft = stats._speed;
    }
    protected void EndAction()
    {
        actionsLeft--;
        if (actionsLeft <= 0) turnManager.PassTurn(this);
        else turnManager.StartNextTurn();
    }
    protected void Atack(int averageBaseDamage, float desviation, float bonusDamage, int amountOfHits, CharacterOnGround target, float duration, string animation)
    {
        StartCoroutine(AtackCo(averageBaseDamage, desviation, bonusDamage, amountOfHits, new CharacterOnGround[] { target }, duration, animation));
    }
    protected void Atack(int averageBaseDamage, float desviation, float bonusDamage, int amountOfHits, CharacterOnGround[] target, float duration, string animation)
    {
        StartCoroutine(AtackCo(averageBaseDamage, desviation, bonusDamage, amountOfHits, target, duration, animation));
    }
    private IEnumerator AtackCo(int averageBaseDamage, float desviation, float bonusDamage, int amountOfHits, CharacterOnGround[] target, float duration, string animation)
    {
        isAtacking = true;

        if (target.Length == 1 && target[0] != null) transform.LookAt(target[0].transform);

        for (int i = 0; i < amountOfHits; i++)
        {
            anim.Play(animation);
            yield return new WaitForSeconds(duration);
            //DESVÍA MEDIANTE LA DISTRIBUCIÓN NORMAL EL DAÑO PROMEDIO CON LA DESVIACIÓN
            int damage = (int)Mathf.Max((averageBaseDamage + desviation * Mathf.Sqrt(-2f * Mathf.Log(Random.value)) * Mathf.Cos(2f * Mathf.PI * Random.value)), 0);
            //USA EL DAÑO RESULTANTE MULTIPLICADO POR EL BONUS
            if (target != null) foreach (CharacterOnGround individualTarget in target) if (individualTarget != null) individualTarget.stats._life -= (int)(damage * bonusDamage);
        }
        EndAction();
        isAtacking = false;
    }
    protected void LookToIndex(int directionIndex)
    {
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
    }
}
