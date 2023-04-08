using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    public CharacterController controller;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        //Vector3 velocity = new Vector3(-hInput, 0, -vInput);
        Vector3 direction = -transform.forward * vInput + -transform.right * hInput;
        controller.SimpleMove(direction * speed);
    }
}
