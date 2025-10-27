using UnityEngine;
using System.Collections;

public class SmoothMovement : MonoBehaviour

{
    [Header("Ajustes de movimiento")]
    public float moveSpeed = 3f; 
    public bool rotateTowardsMovement = true; 

    private bool isMoving = false;

    public IEnumerator MoveTo(Vector3 targetPosition)
    {
        if (isMoving) yield break; 
        isMoving = true;

        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        float distance = Vector3.Distance(startPosition, targetPosition);
        float duration = distance / moveSpeed;



        // psra q gire hacia la dirección del movimiento
        if (rotateTowardsMovement)
        {
            Vector3 direction = (targetPosition - startPosition).normalized;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
            }
        }

        // q el movimiento empiece y acabe suave
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            t = Mathf.SmoothStep(0, 1, t); 

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; 
        isMoving = false;
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}

    

