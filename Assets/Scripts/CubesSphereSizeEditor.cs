using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(CubeSphereSize)), CanEditMultipleObjects]
public class CubeSphereSizeEditor : Editor
{
    private bool areCubesEnabled = true;  // Track the enable/disable state for cubes
    private bool areSpheresEnabled = true;  // Track the enable/disable state for spheres

    public override void OnInspectorGUI()
    {
        // Draw the default inspector GUI
        DrawDefaultInspector();

        // Get the target object (the CubeSphereSize script)
        CubeSphereSize cubeSphereSize = (CubeSphereSize)target;

        ChangeSizeWarning(cubeSphereSize);

        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("Select all cubes"))
            {
                SelectAllObjectsOfType(CubeSphereSize.ShapeType.Cube);
            }

            if (GUILayout.Button("Select all spheres"))
            {
                SelectAllObjectsOfType(CubeSphereSize.ShapeType.Sphere);
            }
        }

        // Clear selection button
        if (GUILayout.Button("Clear selection"))
        {
            Selection.objects = new Object[0];
        }

        using (new EditorGUILayout.HorizontalScope())
        {
            // Set button color based on whether cubes are enabled or disabled
            Color cubeButtonColor = areCubesEnabled ? Color.green : Color.red;
            GUI.backgroundColor = cubeButtonColor;

            if (GUILayout.Button("Disable/Enable all cubes", GUILayout.Height(40)))
            {
                ToggleObjectsEnabledState(CubeSphereSize.ShapeType.Cube, areCubesEnabled);
                areCubesEnabled = !areCubesEnabled;
            }

            // Set button color based on whether spheres are enabled or disabled
            Color sphereButtonColor = areSpheresEnabled ? Color.green : Color.red;
            GUI.backgroundColor = sphereButtonColor;

            if (GUILayout.Button("Disable/Enable all spheres", GUILayout.Height(40)))
            {
                ToggleObjectsEnabledState(CubeSphereSize.ShapeType.Sphere, areSpheresEnabled);
                areSpheresEnabled = !areSpheresEnabled;
            }
        }
    }

    // Method to display warnings based on the current size settings
    public void ChangeSizeWarning(CubeSphereSize cubeSphereSize)
    {
        // Check sphere size for warnings
        if (cubeSphereSize.shapeType == CubeSphereSize.ShapeType.Sphere)
        {
            if (cubeSphereSize.sphereSize > 3f)
            {
                EditorGUILayout.HelpBox("Sphere size cannot be greater than 3", MessageType.Warning);
            }
            else if (cubeSphereSize.sphereSize <= 0f)
            {
                EditorGUILayout.HelpBox("Sphere size cannot be less than or equal to 0", MessageType.Warning);
            }
        }

        // Check cube size for warnings
        if (cubeSphereSize.shapeType == CubeSphereSize.ShapeType.Cube)
        {
            if (cubeSphereSize.cubeSize > 3f)
            {
                EditorGUILayout.HelpBox("Cube size cannot be greater than 3", MessageType.Warning);
            }
            else if (cubeSphereSize.cubeSize <= 0f)
            {
                EditorGUILayout.HelpBox("Cube size cannot be less than or equal to 0", MessageType.Warning);
            }
        }
    }

    private void SelectAllObjectsOfType(CubeSphereSize.ShapeType shapeType)
    {
        var allObjects = GameObject.FindObjectsOfType<CubeSphereSize>();
        var filteredObjects = allObjects
            .Where(obj => obj.shapeType == shapeType)
            .Select(obj => obj.gameObject)
            .ToArray();
        Selection.objects = filteredObjects;
    }

    private void ToggleObjectsEnabledState(CubeSphereSize.ShapeType shapeType, bool areCurrentlyEnabled)
    {
        // Use Resources.findobjectsoftypeall to find active and inactive objects
        var allObjects = Resources.FindObjectsOfTypeAll<CubeSphereSize>();

        foreach (var obj in allObjects)
        {
            if (obj.shapeType == shapeType)
            {
                obj.gameObject.SetActive(!areCurrentlyEnabled); // Toggle active state based on current state
            }
        }
    }
}


