using UnityEngine;

public class Saw : MonoBehaviour
{
    private const float epsilon = 3f;

    [SerializeField]
    private Transform target;
    
    [SerializeField]
    private float forceModifier = 800f;

    [SerializeField]
    private float speed = 2.05f;

    private float smoothTime = 0.25f;
    private Vector3 velocity;

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 targetPosition = transform.position;
        targetPosition.x += speed;
        targetPosition.y = target.position.y + epsilon;

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition,
                                                    ref velocity, smoothTime);
        transform.position = smoothPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Kill();
            player.Rigidbody.AddForce(Vector3.up * forceModifier);
            target = null;
        }
    }
}
