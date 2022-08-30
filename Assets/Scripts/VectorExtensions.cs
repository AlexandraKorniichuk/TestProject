using UnityEngine;

public class VectorExtensions
{
    public static Vector3 GetConverse(Vector3 v) =>
        new Vector3(1 / v.x, 1 / v.y, 1 / v.z);

    public static Vector3 GetMultiplied(Vector3 v1, Vector3 v2) =>
        new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
}
