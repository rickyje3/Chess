using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSphereSize : MonoBehaviour
{
    public enum ShapeType
    {
        None,
        Cube,
        Sphere
    }

    public ShapeType shapeType; // Property to determine if the object is a cube or sphere
    public float sphereSize = 1f;
    public float cubeSize = 1f;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeSize();
        }
    }

    public void ChangeSize()
    {
        if (shapeType == ShapeType.Sphere)
        {
            // Change sphere siZE
            transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);
        }
        else if (shapeType == ShapeType.Cube)
        {
            // Change cube size
            transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        }
    }
}
