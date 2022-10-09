using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    private PlayerController inputActions;
    Mouse mouse;
    private void Awake()
    {
        inputActions = new PlayerController();
        mouse = Mouse.current;
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Attack.started += _ => Debug.Log("Started");
        inputActions.Player.Attack.performed += _ => Debug.Log("Performed");
        inputActions.Player.Attack.canceled += _ => Debug.Log("Canceled");
    }

    private void Update()
    {
        Debug.Log(mouse.leftButton.isPressed);
    }

}
