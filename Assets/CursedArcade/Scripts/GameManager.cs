using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void CheckEnemyNumber()
    {
        if (FindAnyObjectByType<TurnManager>().turnList.Count - 1 == 0)
        {
            if (FindAnyObjectByType<PlayerController>() != null) WinGame();
            else LoseGame();
        }
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
