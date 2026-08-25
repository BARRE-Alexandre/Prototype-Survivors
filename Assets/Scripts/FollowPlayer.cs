using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0,10,0);

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        transform.position = player.transform.position + offset;
    }
}
