using UnityEngine;

namespace DefaultNamespace
{
    public class UIManager : MonoBehaviour
    {
        public GameObject WinScreenGameObject;
        public GameObject LoseScreenGameObject;
        public GameManager GameManager;

        public void ShowWinScreen()
        {
            WinScreenGameObject.SetActive(true);
        }

        public void ShowLoseScreen()
        {
            LoseScreenGameObject.SetActive(true);
        }

        public void OnLoseScreenRetryButtonClicked()
        {
            GameManager.HandleRestartGame();
        }
    }
}