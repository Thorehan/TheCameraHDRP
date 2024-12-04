using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isGrounded;

    private float speed = 5f;
    
    public float gravity = -9.8f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    // InputManager.cs inputlarýna ulaþ ve character controller'a uygula
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDir = Vector3.zero;

        moveDir.x = input.x;
        moveDir.z = input.y;

        controller.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);
        playerVelocity.y = gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }


}
