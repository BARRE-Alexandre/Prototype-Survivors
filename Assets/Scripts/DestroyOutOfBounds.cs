using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float xBounds = 30.0f;
    private float zBounds = 30.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
    }

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
