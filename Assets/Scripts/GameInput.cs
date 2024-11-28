using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnShotPerformed;
    public event EventHandler OnShotCanceled;

    private PlayerInputAction playerInput;

    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } 
        else
        {
            Instance = this;
        }

        playerInput = new PlayerInputAction();
        playerInput.Player.Enable();    
        playerInput.Player.Shot.performed += Shot_performed;
        playerInput.Player.Shot.canceled += Shot_canceled;
    }

    private void Shot_canceled(InputAction.CallbackContext context)
    {
        OnShotCanceled?.Invoke(this, EventArgs.Empty);
    }

    private void Shot_performed(InputAction.CallbackContext context)
    {
        OnShotPerformed?.Invoke(this, EventArgs.Empty);
    }


    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
