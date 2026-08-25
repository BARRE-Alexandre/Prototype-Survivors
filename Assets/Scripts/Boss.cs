using UnityEngine;
// INHERITANCE
public class Boss : EnemyControls
{
    public GameObject bulletPrefab;
    private float fireRate = 2.0f;
    private float nextShot;
    protected override float GetSpeed()
    {
        return 0.5f;
    }

    protected override int GetHealth()
    {
        return 50;
    }
    public override int GetScore()
    {
        return 25;
    }

    void Update()
    {
        FollowPlayer();
        LookAtPlayer();

        if (Time.time >= nextShot)
        {
            Attack();
            nextShot = Time.time + fireRate;
        }  
    }

    protected override void FollowPlayer()
    {
        if (playerTransform == null)
        {
            return;
        }

        transform.Translate(GetSpeed() * Time.deltaTime * (playerTransform.position - transform.position).normalized);
    }

    protected override void LookAtPlayer()
    {
        if (playerTransform == null)
        {
            return;
        }

        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void Attack()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

}
