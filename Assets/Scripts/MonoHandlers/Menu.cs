using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Text _highScoreText;

    private void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        SetHighscoreText();
    }

    private void SetHighscoreText()
    {
        _highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(StartGame);
    }
}
