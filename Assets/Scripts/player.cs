using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 4f;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
