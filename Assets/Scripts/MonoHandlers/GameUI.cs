using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text healthText;
    [SerializeField] private GameObject gameEnd;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void SetHealth(float health)
    {
        healthText.text = "Health: " + health;
    }

    public void ShowGameEnd(bool show)
    {
        gameEnd.SetActive(show);
    }

    public void ShowUI(bool show)
    {
        scoreText.gameObject.SetActive(show);
        healthText.gameObject.SetActive(show);
    }

    private void RestartGame()
    {
        ShowGameEnd(false);
    }

    private void OnDestroy()
    {
        restartButton.onClick.RemoveListener(RestartGame);
    }
}
