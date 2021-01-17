using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private float smoothTime = 0.5f;
    private Vector3 offset = new Vector3(5f, 0.8f, -1f);
    private Vector3 velocity;

    private void Update()
    {
        if (target == null)
        {
            return;
        }    

        Vector3 targetPosition = target.position + offset;

        if (MathUtils.AreApproximatelyEqual(transform.position, targetPosition))
        {
            return;
        }

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition,
                                                    ref velocity, smoothTime);
        transform.position = smoothPosition;
    }
}
