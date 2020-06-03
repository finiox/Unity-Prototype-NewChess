// GENERATED AUTOMATICALLY FROM 'Assets/Input/DeveloperControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DeveloperControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DeveloperControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DeveloperControls"",
    ""maps"": [
        {
            ""name"": ""DeveloperConsole"",
            ""id"": ""34e38bab-9e67-43db-b390-2b3789bd0608"",
            ""actions"": [
                {
                    ""name"": ""Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""dbeee146-5b54-41c4-85de-d9760c29d0a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""41c55bac-7551-440f-837d-267ef61bba29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f61b0f54-f04e-4d1c-8748-aa245a83235a"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7a123d3-503f-47b8-98d9-f98513b9acb7"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55b46076-1b89-408f-aeb2-fb2668b82ea7"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // DeveloperConsole
        m_DeveloperConsole = asset.FindActionMap("DeveloperConsole", throwIfNotFound: true);
        m_DeveloperConsole_Toggle = m_DeveloperConsole.FindAction("Toggle", throwIfNotFound: true);
        m_DeveloperConsole_Enter = m_DeveloperConsole.FindAction("Enter", throwIfNotFound: true);
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

    // DeveloperConsole
    private readonly InputActionMap m_DeveloperConsole;
    private IDeveloperConsoleActions m_DeveloperConsoleActionsCallbackInterface;
    private readonly InputAction m_DeveloperConsole_Toggle;
    private readonly InputAction m_DeveloperConsole_Enter;
    public struct DeveloperConsoleActions
    {
        private @DeveloperControls m_Wrapper;
        public DeveloperConsoleActions(@DeveloperControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Toggle => m_Wrapper.m_DeveloperConsole_Toggle;
        public InputAction @Enter => m_Wrapper.m_DeveloperConsole_Enter;
        public InputActionMap Get() { return m_Wrapper.m_DeveloperConsole; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DeveloperConsoleActions set) { return set.Get(); }
        public void SetCallbacks(IDeveloperConsoleActions instance)
        {
            if (m_Wrapper.m_DeveloperConsoleActionsCallbackInterface != null)
            {
                @Toggle.started -= m_Wrapper.m_DeveloperConsoleActionsCallbackInterface.OnToggle;
                @Toggle.performed -= m_Wrapper.m_DeveloperConsoleActionsCallbackInterface.OnToggle;
                @Toggle.canceled -= m_Wrapper.m_DeveloperConsoleActionsCallbackInterface.OnToggle;
                @Enter.started -= m_Wrapper.m_DeveloperConsoleActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_DeveloperConsoleActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_DeveloperConsoleActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_DeveloperConsoleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Toggle.started += instance.OnToggle;
                @Toggle.performed += instance.OnToggle;
                @Toggle.canceled += instance.OnToggle;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
            }
        }
    }
    public DeveloperConsoleActions @DeveloperConsole => new DeveloperConsoleActions(this);
    public interface IDeveloperConsoleActions
    {
        void OnToggle(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
}
