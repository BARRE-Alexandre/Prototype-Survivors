using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Start()
    {
        if (MainManager.Instance != null)
        {
            scoreText.SetText("Best Score : " + MainManager.Instance.playerScore);
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    // ABSTRACTION
    public void Exit()
    {
        MainManager.Instance.SaveScore();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
