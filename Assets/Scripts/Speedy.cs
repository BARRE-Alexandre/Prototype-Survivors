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
    public override int GetScore()
    {
        return 3;
    }
    protected override void FollowPlayer()
    {
        if (playerTransform == null)
        {
            return;
        }

        transform.Translate(GetSpeed() * Time.deltaTime * (playerTransform.position - transform.position).normalized);
    }
}
