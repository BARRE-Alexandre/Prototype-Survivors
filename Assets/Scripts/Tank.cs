using UnityEngine;

public class Tank : EnemyControls
{
    protected override float GetSpeed()
    {
        return 1.0f;
    }

    protected override int GetHealth()
    {
        return 3;
    }

    protected override void FollowPlayer()
    {
        transform.Translate(GetSpeed() * Time.deltaTime * (playerTransform.position - transform.position).normalized);
    }
}
