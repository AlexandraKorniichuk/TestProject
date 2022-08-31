using System;
using UnityEngine;

public class VectorExtensions
{
    public static Vector3 GetConverse(Vector3 v) =>
        new Vector3(1 / v.x, 1 / v.y, 1 / v.z);

    public static Vector3 GetMultiplied(Vector3 v1, Vector3 v2) =>
        new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);

    public static Vector3 GetPoint(Vector3 direction, float ballRadius)
    {
        Vector3 point = Vector3.zero;
        float poweredDivision = (direction.x / direction.z) * (direction.x / direction.z);
        point.z = ballRadius / Mathf.Sqrt(poweredDivision + 1);
        point.x = Mathf.Sqrt(ballRadius * ballRadius - point.z * point.z);
        return point;
    }
}
