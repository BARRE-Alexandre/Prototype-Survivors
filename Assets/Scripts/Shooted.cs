using UnityEngine;

public class Shooted : MonoBehaviour
{

    private float speed = 40.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }
}
