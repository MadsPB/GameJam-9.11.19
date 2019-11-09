using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;
    public static bool didShoot = false;
    public static GameManager instance;
    
    public bool IsGameActive;

    void Start()
    {
        instance = this;
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

    public void HandleWin()
    {
        if (IsGameActive)
        {
            IsGameActive = false;
            UIManager.ShowWinScreen();
        }
    }

    public void HandleLose()
    {
        if (IsGameActive)
        {
            IsGameActive = false;
            UIManager.ShowLoseScreen();
        }
    }
}