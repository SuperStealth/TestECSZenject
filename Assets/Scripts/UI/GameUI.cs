using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _healthText;
    [SerializeField] private GameObject _gameEnd;
    [SerializeField] private Button _restartButton;

    public Action RestartGameAction;

    private void Awake()
    {
        _restartButton.onClick.AddListener(RestartGame);
    }

    public void SetScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }

    public void SetHealth(float health)
    {
        _healthText.text = "Health: " + health;
    }

    public void ShowGameEnd(bool show)
    {
        _gameEnd.SetActive(show);    
    }

    public void ShowUI(bool show)
    {
        _scoreText.gameObject.SetActive(show);
        _healthText.gameObject.SetActive(show);
    }

    private void RestartGame()
    {
        RestartGameAction?.Invoke();
    }

    private void OnDestroy()
    {
        _restartButton.onClick.RemoveListener(RestartGame);
    }
}
