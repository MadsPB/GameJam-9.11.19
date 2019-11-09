using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Bear Bear;
    public UIManager UIManager;
    public static bool didShoot = false;

    public bool IsGameActive;

    void Start()
    {
        didShoot = false;
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

    public void HandleDialogueFinished()
    {
        Bear.gameObject.SetActive(true);
    }

    public void HandleRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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