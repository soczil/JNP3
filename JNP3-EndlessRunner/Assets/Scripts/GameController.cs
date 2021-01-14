using UnityEngine;

public class GameController : ASingleton<GameController>
{
    private ulong points = 0;

    public void HandleCoinPickedUp(Coin coin)
    {
        if (coin == null)
        {
            return;
        }

        points += coin.Points;
        Debug.LogFormat("Total points: {0}", points);
    }
}