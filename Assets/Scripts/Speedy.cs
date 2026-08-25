using UnityEngine;
// INHERITANCE
public class Speedy : EnemyControls
{
    // ENCAPSULATION
    protected override float GetSpeed()
    {
        return 5.0f;
    }
    // ENCAPSULATION
    protected override int GetHealth()
    {
        return base.GetHealth();
    }
    // POLYMORPHISM
    public override int GetScore()
    {
        return 3;
    }
    // POLYMORPHISM
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
