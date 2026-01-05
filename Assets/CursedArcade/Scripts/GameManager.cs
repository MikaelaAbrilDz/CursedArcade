using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void CheckEnemyNumber()
    {
        if (FindAnyObjectByType<TurnManager>().turnList.Count - 1 == 0 && FindAnyObjectByType<PlayerController>() != null) WinGame();
        
        if (FindAnyObjectByType<PlayerController>() == null) LoseGame();
    }
    public void WinGame()
    {
        print("WIN");
    }
    public void LoseGame()
    {
        print("LOSE");
    }
}
