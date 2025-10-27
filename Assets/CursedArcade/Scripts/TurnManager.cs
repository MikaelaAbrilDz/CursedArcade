using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public List<BasicEntity> turnList = new List<BasicEntity>();
    private void Start()
    {
        turnList.Add(FindAnyObjectByType<PlayerController>());
        turnList.Add(null);
    }
    private void Update()
    {
        if (turnList[0] == null) PassTurn(null);
    }
    public void PassTurn(CharacterOnGround turnPasser)
    {
        turnList.Remove(turnPasser);
        turnList.Add(turnPasser);
    }
}
