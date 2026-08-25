using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float xBounds = 44.0f;
    private float zBounds = 44.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
    }
// ABSTRACTION
    private void Destroy()
    {
        if (transform.position.x < -xBounds || transform.position.x > xBounds)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < -zBounds || transform.position.z > zBounds)
        {
            Destroy(gameObject);
        }
    }
}
