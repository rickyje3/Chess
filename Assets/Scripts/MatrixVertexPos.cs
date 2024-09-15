using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixVertexPos : MonoBehaviour
{
    public Mesh exampleMesh;

    // Start is called before the first frame update
    void Start()
    {
        //Get the mesh filter attached to this object
        exampleMesh = GetComponent<MeshFilter>().mesh;

        //Get the verts on the example mesh
        Vector3[] vertices = exampleMesh.vertices;

        //Move each vertex by 2 on each eaxis
        Matrix4x4 translateMatrix = Matrix4x4.Translate(new Vector3(2, 2, 2));

        //Rotate 90 degrees around x 
        Matrix4x4 rotateMatrix = Matrix4x4.Rotate(Quaternion.Euler(90, 0, 0));

        //Combine the 2 into one matrix
        Matrix4x4 transformMatrix = translateMatrix * rotateMatrix;

        // Apply transformation to each vertex
        for (int i = 0; i < vertices.Length; i++)
        {
            // Convert the vertex to a Vector4 to apply the 4x4 matrix
            Vector3 vertex = vertices[i];
            Vector4 vertex4 = new Vector4(vertex.x, vertex.y, vertex.z, 1);

            // Apply transform vertex
            Vector4 transformedVertex4 = transformMatrix * vertex4;

            // Update the vertex back to vector 3
            vertices[i] = new Vector3(transformedVertex4.x, transformedVertex4.y, transformedVertex4.z);
        }

        //Reassign the transformed verts back to the mesh
        exampleMesh.vertices = vertices;
        //Recalculate normals after transformation
        exampleMesh.RecalculateNormals();
        //Recalculate bounds after transformation
        exampleMesh.RecalculateBounds();
    }
}
