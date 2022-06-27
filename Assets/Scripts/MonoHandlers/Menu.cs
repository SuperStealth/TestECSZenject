using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Text highScoreText;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        SetHighscoreText();
    }

    private void SetHighscoreText()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartGame);
    }
}
