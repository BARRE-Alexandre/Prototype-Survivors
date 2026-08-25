using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI wavesText;
    public TextMeshProUGUI enemiesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button exitButton;
    private WaveManager waveScript;
    private PlayerController playerScript;
    public int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waveScript = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        wavesText.SetText("Waves : " + waveScript.waveNumber);
        enemiesText.SetText("Enemies Remaining : " + waveScript.EnemiesLeft);
        livesText.SetText("Lives : " + playerScript.playerHealth);
        scoreText.SetText("Score : " + score);

        if (MainManager.Instance.playerScore < score)
        {
            MainManager.Instance.playerScore = score;
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void Restart()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

}
