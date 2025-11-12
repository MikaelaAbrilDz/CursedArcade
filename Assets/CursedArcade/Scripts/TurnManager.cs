using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public List<CharacterOnGround> turnList = new List<CharacterOnGround>();
    private void Start()
    {
        turnList.Add(FindAnyObjectByType<PlayerController>());
        turnList.Add(FindAnyObjectByType<EnemyAI>());
    }
    private void Update()
    {
        if (turnList[0] == null) PassTurn(null);
    }
    public void PassTurn(CharacterOnGround turnPasser)
    {
        turnList.Remove(turnPasser);
        turnList.Add(turnPasser);
        turnList[0].StartTurn();
    }
}
