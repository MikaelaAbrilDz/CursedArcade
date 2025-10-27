using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharactersOnGround
{
    private SmoothMovement smoothMovement;

    void Awake()
    {
        
        smoothMovement = GetComponent<SmoothMovement>();

        if (smoothMovement == null)
        {
            Debug.LogWarning("No se encontró el componente SmoothMovement en el jugador.");
        }
    }

    
    public void OnMovementUp(InputAction.CallbackContext context)
    {
        TryMove(0, context);
    }

    public void OnMovementRight(InputAction.CallbackContext context)
    {
        TryMove(1, context);
    }

    public void OnMovementDown(InputAction.CallbackContext context)
    {
        TryMove(2, context);
    }

    public void OnMovementLeft(InputAction.CallbackContext context)
    {
        TryMove(3, context);
    }

    
    void TryMove(int directionIndex, InputAction.CallbackContext context)
    {
        
        if (!context.performed)
            return;

        
        TurnManager turnManager = FindAnyObjectByType<TurnManager>();
        if (turnManager == null)
        {
            Debug.LogError("No se encontró el TurnManager en la escena.");
            return;
        }

        
        if (turnManager.turnList[0] != GetComponent<BasicEntity>())
            return;

        
        if (smoothMovement != null && smoothMovement.IsMoving())
            return;

        
        var currentChecker = CurrentChecker();
        if (currentChecker == null || currentChecker.sideCheckers == null || currentChecker.sideCheckers.Length <= directionIndex)
        {
            Debug.LogWarning("No hay casilla válida en esa dirección.");
            return;
        }

        Vector3 targetPos = currentChecker.sideCheckers[directionIndex].transform.position;

        
        StartCoroutine(smoothMovement.MoveTo(targetPos));

        
        turnManager.PassTurn(GetComponent<BasicEntity>());
    }
}

