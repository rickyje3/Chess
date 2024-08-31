using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PotentialMoves : MonoBehaviour
{
    public enum ChessTypes
    {
        Rook,
        Pawn,
        Bishop, 
        Knight,
        Queen,
        King,
    }

    public ChessTypes chessTypes;

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        //checks which piece is selected and shows potential moves 
        switch (chessTypes)
        {
            case ChessTypes.Pawn:
                ForwardMove();
                break;
            case ChessTypes.Rook:
                HorizontalMove();
                ForwardMove();
                BackwardMove();
                break;
            case ChessTypes.Bishop:
                DiagonalMove();
                BackDiagonalMove();
                break;
            case ChessTypes.King:
                ForwardMove();
                DiagonalMove();
                HorizontalMove();
                BackwardMove();
                BackDiagonalMove();
                break;
            case ChessTypes.Queen:
                ForwardMove();
                DiagonalMove();
                HorizontalMove();
                BackwardMove();
                BackDiagonalMove();
                break;
            case ChessTypes.Knight:          
                KnightMove();
                break;
        }
    }

    private void ForwardMove()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0,1,0));
    }

    private void BackwardMove()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -1, 0));
    }

    private void HorizontalMove()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(1, 0, 0));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-1, 0, 0));
    }

    private void DiagonalMove()
    {
       
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(1,1,0));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-1, 1, 0));
    }

    private void BackDiagonalMove()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(1, -1, 0));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-1, -1, 0));
    }

    private void KnightMove()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, 2, 0));
        Gizmos.DrawLine(transform.position + new Vector3(0, 2, 0), transform.position + new Vector3(1, 2, 0));
        Gizmos.DrawLine(transform.position + new Vector3(0, 2, 0), transform.position + new Vector3(-1, 2, 0));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(2, 0, 0));
        Gizmos.DrawLine(transform.position + new Vector3(2, 0, 0), transform.position + new Vector3(2, 1, 0));
        Gizmos.DrawLine(transform.position + new Vector3(2, 0, 0), transform.position + new Vector3(2, -1, 0));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-2, 0, 0));
        Gizmos.DrawLine(transform.position + new Vector3(-2, 0, 0), transform.position + new Vector3(-2, 1, 0));
        Gizmos.DrawLine(transform.position + new Vector3(-2, 0, 0), transform.position + new Vector3(-2, -1, 0));
    }
}