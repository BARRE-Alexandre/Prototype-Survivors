using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    private GameUIHandler gameUIHandler;
    protected Transform playerTransform;
    protected int currentHealth;
    protected virtual float GetSpeed()
    {
        return 2.5f;
    }
    protected virtual int GetHealth()
    {
        return 1;
    }
    public virtual int GetScore()
    {
        return 1;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameUIHandler = GameObject.Find("Canvas").GetComponent<GameUIHandler>();

        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        currentHealth = GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        LookAtPlayer();
    }

    protected virtual void FollowPlayer()
    {
        if (playerTransform == null)
        {
            return;
        }
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0;

        transform.Translate(GetSpeed() * Time.deltaTime * direction.normalized);
    }

    protected virtual void LookAtPlayer()
    {
        if (playerTransform == null)
        {
            return;
        }
    }

    public void TakeDammage()
    {
        currentHealth--;

        if (currentHealth == 0)
        {
            gameUIHandler.score += GetScore();
            Destroy(gameObject);
        }
    }
}
