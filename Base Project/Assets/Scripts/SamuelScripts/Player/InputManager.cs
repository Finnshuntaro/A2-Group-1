using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    public GameObject dialogueBox;
    private Dialogue1 dialogueScript;  // Reference to the Dialogue1 script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.Jump();
    }

    void Start()
    {
        dialogueScript = dialogueBox.GetComponent<Dialogue1>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dialogueScript == null || !dialogueScript.isDialoguePlaying)
        {
            motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        }
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
