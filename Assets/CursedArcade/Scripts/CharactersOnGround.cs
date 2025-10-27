using UnityEngine;
using UnityEngine.InputSystem;

public class CharactersOnGround : BasicEntity
{
    protected void Move(int directionIndex)
    {
        LeanTween.move(gameObject, CurrentChecker().sideCheckers[directionIndex].transform.position, 0.2f).setEaseOutQuad();
    }
}
