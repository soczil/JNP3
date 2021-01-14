using System;
using UnityEngine;

public class MathUtils : MonoBehaviour
{
    private const float DEFAULT_EPSILON = 0.01f;

    public static bool AreApproximatelyEqual(float a, float b, float eps = DEFAULT_EPSILON)
    {
        return Math.Abs(a - b) <= eps;
    }

    public static bool AreApproximatelyEqual(Vector3 a, Vector3 b, float eps = DEFAULT_EPSILON)
    {
        return AreApproximatelyEqual(a.x, b.x, eps)
               && AreApproximatelyEqual(a.y, b.y, eps)
               && AreApproximatelyEqual(a.z, b.z, eps);
    }
}
