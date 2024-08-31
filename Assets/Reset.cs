using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Rigidbody rgbd;
    
    private void Start()
    {
        Rigidbody rgbd = GetComponent<Rigidbody>();
    }

    [ContextMenu("Reset Object")]
    public void ResetObject()
    {
        if (rgbd != null)
        {
            Destroy(rgbd);
            Debug.Log("Rigidbody destroyed");
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
}
