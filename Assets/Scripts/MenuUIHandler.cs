using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuUIHandler : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Start()
    {
        scoreText.SetText("Score");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
