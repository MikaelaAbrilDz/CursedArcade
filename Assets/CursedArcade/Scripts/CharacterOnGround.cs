using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class CharacterOnGround : BasicEntity
{
    protected TurnManager turnManager;
    bool isMoving = false, isAtacking = false;
    public Animator anim;
    CharacterStats stats;
    private void Start()
    {
        turnManager = FindAnyObjectByType<TurnManager>();

        anim = GetComponentInChildren<Animator>();

        stats = GetComponent<CharacterStats>();
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
    protected IEnumerator AtackCo(int averageBaseDamage, float desviation, float bonusDamage, int amountOfHits, CharacterOnGround target, float duration, string animation)
    {
        isAtacking = true;
        for (int i = 0; i < amountOfHits; i++)
        {
            anim.Play(animation);
            //DESVÍA MEDIANTE LA DISTRIBUCIÓN NORMAL EL DAÑO PROMEDIO CON LA DESVIACIÓN
            int damage = (int)(averageBaseDamage + desviation * Mathf.Sqrt(-2f * Mathf.Log(Random.value)) * Mathf.Cos(2f * Mathf.PI * Random.value));
            //USA EL DAÑO RESULTANTE MULTIPLICADO POR EL BONUS
            target.stats._life -= (int)(damage * bonusDamage);
            yield return new WaitForSeconds(duration);
        }
        isAtacking = false;
    }
}
