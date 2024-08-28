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

    public GameObject king;
    public GameObject queen;
    public GameObject knight;
    public GameObject bishop;
    public GameObject rook;
    public GameObject pawn;

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


        if (king)
        {
            Vector3 upDirection = transform.TransformDirection(Vector3.up) * gizmoSize;
            Vector3 leftDirection = transform.TransformDirection(Vector3.left) * gizmoSize;
            Vector3 rightDirection = transform.TransformDirection(Vector3.right) * gizmoSize;
            Vector3 downDirection = transform.TransformDirection(Vector3.down) * gizmoSize;
            Gizmos.DrawRay(king.transform.position, upDirection);
            Gizmos.DrawRay(king.transform.position, leftDirection);
            Gizmos.DrawRay(king.transform.position, rightDirection);
            Gizmos.DrawRay(king.transform.position, downDirection);
        }

        if (queen)
        {
            Vector3 upDirection = transform.TransformDirection(Vector3.up) * gizmoSize;
            Vector3 leftDirection = transform.TransformDirection(Vector3.left) * gizmoSize;
            Vector3 rightDirection = transform.TransformDirection(Vector3.right) * gizmoSize;
            Vector3 downDirection = transform.TransformDirection(Vector3.down) * gizmoSize;
            Vector3 upLeftDirection = transform.TransformDirection(new Vector3(0, 0, 30)) * gizmoSize;
            Vector3 upRightDirection = transform.TransformDirection(new Vector3(0, 0, 315)) * gizmoSize;
            Vector3 downRightDirection = transform.TransformDirection(new Vector3(0, 0, 225)) * gizmoSize;
            Vector3 downLeftDirection = transform.TransformDirection(new Vector3(0, 0, 135)) * gizmoSize;
            Gizmos.DrawRay(queen.transform.position, upDirection);
            Gizmos.DrawRay(queen.transform.position, leftDirection);
            Gizmos.DrawRay(queen.transform.position, rightDirection);
            Gizmos.DrawRay(queen.transform.position, downDirection);
            Gizmos.DrawRay(queen.transform.position, upLeftDirection);
            Gizmos.DrawRay(queen.transform.position, upRightDirection);
            Gizmos.DrawRay(queen.transform.position, downRightDirection);
            Gizmos.DrawRay(queen.transform.position, downLeftDirection);
        }

        if (rook)
        {
            Vector3 upDirection = transform.TransformDirection(Vector3.up) * gizmoSize;
            Vector3 leftDirection = transform.TransformDirection(Vector3.left) * gizmoSize;
            Vector3 rightDirection = transform.TransformDirection(Vector3.right) * gizmoSize;
            Vector3 downDirection = transform.TransformDirection(Vector3.down) * gizmoSize;
            Gizmos.DrawRay(rook.transform.position, upDirection);
            Gizmos.DrawRay(rook.transform.position, leftDirection);
            Gizmos.DrawRay(rook.transform.position, rightDirection);
            Gizmos.DrawRay(rook.transform.position, downDirection);
        }

        if (pawn)
        {
            Vector3 upDirection = transform.TransformDirection(Vector3.up) * gizmoSize;
            Gizmos.DrawRay(pawn.transform.position, upDirection);
        }
    }
}
