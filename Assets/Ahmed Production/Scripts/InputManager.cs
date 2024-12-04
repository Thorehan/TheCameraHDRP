using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerMouseLook look;


    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        look = GetComponent<PlayerMouseLook>();
        motor = GetComponent<PlayerMotor>();
    }

    void FixedUpdate()
    {
        // playermotor'a movement action deðerini kullanarak hareket etmesini saðla.
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
