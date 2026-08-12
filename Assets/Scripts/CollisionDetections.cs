using UnityEngine;

public class CollisionDetections : MonoBehaviour
{
    private EnemyControls enemyScript;
    private void OnTriggerEnter(Collider other)
    {
        enemyScript = other.GetComponent<EnemyControls>();

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            enemyScript.TakeDammage();
        }
    }
}
