using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target; // The target to follow a.k.a. the player
    public Vector3 offset; // Offset from the target position

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            transform.position = target.position + offset;
    }
}
