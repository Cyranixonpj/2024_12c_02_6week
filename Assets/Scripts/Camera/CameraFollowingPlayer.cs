using UnityEngine;

public class CameraFollowingPlayer : MonoBehaviour
{
    public float FollowSpeed = 1;
    public float yOffset = 0;
    public Transform target;

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}