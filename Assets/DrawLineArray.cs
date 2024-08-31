using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineArray : MonoBehaviour
{
    Vector3[] points = new Vector3[]
    {
        new Vector3(0, 0, 0),
        new Vector3(3, 0, 0),
        new Vector3(3, 2, 0),
        new Vector3(1.5f, 3, 0),
        new Vector3(0, 2, 0),
        new Vector3(0, 0, 0)
    };

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + points[0]);
        Gizmos.DrawLine(transform.position + points[0], transform.position + points[1]);
        Gizmos.DrawLine(transform.position + points[1], transform.position + points[2]);
        Gizmos.DrawLine(transform.position + points[2], transform.position + points[3]);
        Gizmos.DrawLine(transform.position + points[3], transform.position + points[4]);
        Gizmos.DrawLine(transform.position + points[4], transform.position + points[5]);
    }
}
