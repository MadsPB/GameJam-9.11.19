using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;

    public bool IsGameActive;

    void Start()
    {
        IsGameActive = true;
    }

    public void HandleBearHitPlanet(Bear bear, Planet planet)
    {
        if (planet.IsTarget)
        {
            HandleWin();
        }
        else
        {
            HandleLose();
        }
    }

    private void HandleWin()
    {
        IsGameActive = false;
        UIManager.ShowWinScreen();
    }

    private void HandleLose()
    {
        IsGameActive = false;
        UIManager.ShowLoseScreen();
    }
}