using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationDelta;

    private Transform sawTransform;

    void Awake()
    {
        sawTransform = GetComponent<Transform>();
    }

    void Update()
    {
        sawTransform.Rotate(rotationDelta * Time.deltaTime);
    }
}
