using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 offset;

    private void LateUpdate()
    {
        if (target == null)
            return;

        transform.position = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            -10f
        );
    }
}