using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    private Color gizmoColor = Color.white;
    private float gizmoSize = 2f;
    public GameObject startVert;
    public GameObject endVert;
    public GameObject startHor;
    public GameObject endHor;

    private void OnDrawGizmos()
    {
        float i;
        float j;
        Gizmos.color = gizmoColor;

        //vertical lines
        for (i = -4f; i < 4.5f; i++)
        {
            Gizmos.DrawLine(startVert.transform.position, endVert.transform.position);
            startVert.transform.position = new Vector3(i, -4, 0);
            endVert.transform.position = new Vector3(i, 4, 0);
        }

        //horizontal lines
        for (j = -4; j < 4.5; j++)
        {
            Gizmos.DrawLine(startHor.transform.position, endHor.transform.position);
            startHor.transform.position = new Vector3(-4f, j, 0);
            endHor.transform.position = new Vector3(4f, j, 0);
        }
    }
}
