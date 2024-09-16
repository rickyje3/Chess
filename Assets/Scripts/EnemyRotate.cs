using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public Transform enemy;
    public Transform player;
    public float rotationSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        //Measures the distance between player and enemy
        float distance = Vector3.Distance(enemy.position, player.position);
        Debug.Log("The enemy is " + distance + " units away from you");

        //This just makes an object rotate on its own. Conflicts with the aim constraint
        //transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);

                              //pivot object   axis to rotate on (Z)  Size of angle to rotate, multiplying by distance makes it faster as it gets further from player
        transform.RotateAround(player.position, new Vector3(0, 0, 1), rotationSpeed * distance * Time.deltaTime);
    }
}
