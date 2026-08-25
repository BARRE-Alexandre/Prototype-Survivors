using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string playerName;
    public int playerScore;

    private void Awake()
    {
        if (Instance!= null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
