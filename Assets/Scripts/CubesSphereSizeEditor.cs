using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

[CustomEditor(typeof(CubeSphereSize)), CanEditMultipleObjects]
public class CubesSphereSizeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        using (new EditorGUILayout.HorizontalScope())
        {

            if (GUILayout.Button("Select all cubes"))
            {
                
                var allCubeBehaviour = GameObject.FindObjectsOfType<CubeSphereSize>();
                var allCubeGameObjects = allCubeBehaviour.Select(cube => cube.gameObject).ToArray();
                Selection.objects = allCubeGameObjects;
                
            }

            //EditorGUILayout.Space();

            if (GUILayout.Button("Select all spheres"))
            {
                
                var allSphereBehaviour = GameObject.FindObjectsOfType<CubeSphereSize>();
                var allSphereGameObjects = allSphereBehaviour.Select(sphere => sphere.gameObject).ToArray();
                Selection.objects = allSphereGameObjects;
            }
        }

            if (GUILayout.Button("Disable/Enable all cubes", GUILayout.Height(40)))
            {
                
                var allCubeBehaviour = GameObject.FindObjectsOfType<CubeSphereSize>();
                var allCubeGameObjects = allCubeBehaviour.Select(cube => cube.gameObject).ToArray();
                Selection.objects = allCubeGameObjects;
            }

            if (GUILayout.Button("Disable/Enable all spheres", GUILayout.Height(40)))
            {
                
                var allSphereBehaviour = GameObject.FindObjectsOfType<CubeSphereSize>();
                var allSphereGameObjects = allSphereBehaviour.Select(sphere => sphere.gameObject).ToArray();
                Selection.objects = allSphereGameObjects;
                
            }
        
    }
}

