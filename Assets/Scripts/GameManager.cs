using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        gameOverPanel.SetActive(false); // Ukryj panel na starcie
    }

    public void EndGame(int currentScore)
    {
        Time.timeScale = 0f; // Zatrzymaj czas w grze
        gameOverPanel.SetActive(true);

        // Obs³uga rekordu (High Score) przez PlayerPrefs
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        finalScoreText.text = "Wynik: " + currentScore;
        highScoreText.text = "Najlepszy: " + highScore;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Przywróæ czas
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Prze³aduj scenê
    }

    public void ExitGame()
    {
        Application.Quit(); // Zamknij grê
        Debug.Log("Gra zosta³a zamkniêta");
    }
}