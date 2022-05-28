using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier 
{
    public static Vector3 GetBezierPoin(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = t - 1f;

        Vector3 bezierPoint =
            oneMinusT * oneMinusT * oneMinusT * p1 +
            3f * oneMinusT * oneMinusT * t * p2 +
            3f * oneMinusT * t * t * p3 +
            t * t * t * p4;

        return bezierPoint;
    }
}
