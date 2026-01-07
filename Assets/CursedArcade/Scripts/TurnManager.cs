using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public List<CharacterOnGround> turnList = new List<CharacterOnGround>();
    private void Start()
    {
        turnList.Add(FindAnyObjectByType<PlayerController>());
        foreach (var enemy in FindObjectsByType<EnemyAI>(FindObjectsSortMode.None)) turnList.Add(enemy);

        turnList[0].SetActionsForTurn();
    }
    private void Update()
    {
        if (turnList[0] == null) PassTurn(null);
    }
    public void PassTurn(CharacterOnGround turnPasser)
    {
        turnList.Remove(turnPasser);
        turnList.Add(turnPasser);
        turnList[0].SetActionsForTurn();
        StartNextTurn();
    }
    public void StartNextTurn()
    {
        turnList[0].StartTurn();
    }
}
