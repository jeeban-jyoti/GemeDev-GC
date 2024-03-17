using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnIInteractionAction;
    public event EventHandler OnJInteractionAction;
    public event EventHandler OnKInteractionAction;
    public event EventHandler OnLInteractionAction;

    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.IInteract.performed += IInteract_Performed;
        playerInputActions.Player.JInteract.performed += JInteract_Performed;
        playerInputActions.Player.KInteract.performed += KInteract_Performed;
        playerInputActions.Player.LInteract.performed += LInteract_Performed;
    }

    private void IInteract_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnIInteractionAction?.Invoke(this, EventArgs.Empty);
    }

    private void JInteract_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnJInteractionAction?.Invoke(this, EventArgs.Empty);
    }

    private void KInteract_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnKInteractionAction?.Invoke(this, EventArgs.Empty);
    }
    private void LInteract_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnLInteractionAction?.Invoke(this, EventArgs.Empty);
    }
}
