using UnityEngine;

public class EnemyControls : MonoBehaviour
{
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        transform.Translate(GetSpeed() * Time.deltaTime * (playerTransform.position - transform.position).normalized);
    }

    protected virtual void LookAtPlayer()
    {
        
    }

    public void TakeDammage()
    {
        currentHealth--;

        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
