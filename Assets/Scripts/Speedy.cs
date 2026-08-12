using UnityEngine;

public class Speedy : EnemyControls
{
    protected override float GetSpeed()
    {
        return 5.0f;
    }
    protected override int GetHealth()
    {
        return base.GetHealth();
    }
    protected override void FollowPlayer()
    {
        transform.Translate(GetSpeed() * Time.deltaTime * (playerTransform.position - transform.position).normalized);
    }
}
