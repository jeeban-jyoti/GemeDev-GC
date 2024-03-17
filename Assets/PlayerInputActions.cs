//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""dae37503-d5c1-4cfb-85f3-dacd1a14a5e0"",
            ""actions"": [
                {
                    ""name"": ""IInteract"",
                    ""type"": ""Button"",
                    ""id"": ""604642ea-e347-4d76-80fe-6282103cc2df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""JInteract"",
                    ""type"": ""Button"",
                    ""id"": ""49a9d0ca-dbd6-4b98-a871-8f776116121a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""KInteract"",
                    ""type"": ""Button"",
                    ""id"": ""367c3630-b678-4ea2-b59f-df0560a1f312"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LInteract"",
                    ""type"": ""Button"",
                    ""id"": ""769b3b4e-87ff-4a18-a7f2-65c8e46beb47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""79e77af6-024c-4005-90b8-c12f968cbed8"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9f86fe4-7cb8-4f41-a9cf-2fc9393446f4"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a09d81f9-436d-42a2-a824-d55f6e7ce4a2"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db9048a2-3877-4976-b69f-1726ff782810"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_IInteract = m_Player.FindAction("IInteract", throwIfNotFound: true);
        m_Player_JInteract = m_Player.FindAction("JInteract", throwIfNotFound: true);
        m_Player_KInteract = m_Player.FindAction("KInteract", throwIfNotFound: true);
        m_Player_LInteract = m_Player.FindAction("LInteract", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_IInteract;
    private readonly InputAction m_Player_JInteract;
    private readonly InputAction m_Player_KInteract;
    private readonly InputAction m_Player_LInteract;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @IInteract => m_Wrapper.m_Player_IInteract;
        public InputAction @JInteract => m_Wrapper.m_Player_JInteract;
        public InputAction @KInteract => m_Wrapper.m_Player_KInteract;
        public InputAction @LInteract => m_Wrapper.m_Player_LInteract;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @IInteract.started += instance.OnIInteract;
            @IInteract.performed += instance.OnIInteract;
            @IInteract.canceled += instance.OnIInteract;
            @JInteract.started += instance.OnJInteract;
            @JInteract.performed += instance.OnJInteract;
            @JInteract.canceled += instance.OnJInteract;
            @KInteract.started += instance.OnKInteract;
            @KInteract.performed += instance.OnKInteract;
            @KInteract.canceled += instance.OnKInteract;
            @LInteract.started += instance.OnLInteract;
            @LInteract.performed += instance.OnLInteract;
            @LInteract.canceled += instance.OnLInteract;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @IInteract.started -= instance.OnIInteract;
            @IInteract.performed -= instance.OnIInteract;
            @IInteract.canceled -= instance.OnIInteract;
            @JInteract.started -= instance.OnJInteract;
            @JInteract.performed -= instance.OnJInteract;
            @JInteract.canceled -= instance.OnJInteract;
            @KInteract.started -= instance.OnKInteract;
            @KInteract.performed -= instance.OnKInteract;
            @KInteract.canceled -= instance.OnKInteract;
            @LInteract.started -= instance.OnLInteract;
            @LInteract.performed -= instance.OnLInteract;
            @LInteract.canceled -= instance.OnLInteract;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnIInteract(InputAction.CallbackContext context);
        void OnJInteract(InputAction.CallbackContext context);
        void OnKInteract(InputAction.CallbackContext context);
        void OnLInteract(InputAction.CallbackContext context);
    }
}
