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
    public override int GetScore()
    {
        return 5;
    }

    protected override void FollowPlayer()
    {
        if (playerTransform == null)
        {
            return;
        }
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0;

        transform.Translate(GetSpeed() * Time.deltaTime * direction.normalized);
    }
}
