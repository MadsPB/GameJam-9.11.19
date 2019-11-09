using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;
    public static bool didShoot = false;
    
    public bool IsGameActive;

    void Start()
    {
        IsGameActive = true;
    }

    public void HandleBearHitPlanet(Bear bear, Planet planet)
    {
        bear.transform.SetParent(planet.transform);
        bear.Rigidbody2D.simulated = false;
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
        if (IsGameActive)
        {
            IsGameActive = false;
            UIManager.ShowWinScreen();
        }
    }

    private void HandleLose()
    {
        if (IsGameActive)
        {
            IsGameActive = false;
            UIManager.ShowLoseScreen();
        }
    }
}