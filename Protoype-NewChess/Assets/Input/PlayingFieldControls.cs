// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayingFieldControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayingFieldControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayingFieldControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayingFieldControls"",
    ""maps"": [
        {
            ""name"": ""PlayField"",
            ""id"": ""ff469d2a-a263-4147-a9aa-001943b5a460"",
            ""actions"": [
                {
                    ""name"": ""SelectTile"",
                    ""type"": ""Button"",
                    ""id"": ""a0145d08-7d36-4cfd-b733-f1a91184f93e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b975fcf9-9280-4470-bef1-3ad9eb0a8d03"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayField
        m_PlayField = asset.FindActionMap("PlayField", throwIfNotFound: true);
        m_PlayField_SelectTile = m_PlayField.FindAction("SelectTile", throwIfNotFound: true);
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

    // PlayField
    private readonly InputActionMap m_PlayField;
    private IPlayFieldActions m_PlayFieldActionsCallbackInterface;
    private readonly InputAction m_PlayField_SelectTile;
    public struct PlayFieldActions
    {
        private @PlayingFieldControls m_Wrapper;
        public PlayFieldActions(@PlayingFieldControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectTile => m_Wrapper.m_PlayField_SelectTile;
        public InputActionMap Get() { return m_Wrapper.m_PlayField; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayFieldActions set) { return set.Get(); }
        public void SetCallbacks(IPlayFieldActions instance)
        {
            if (m_Wrapper.m_PlayFieldActionsCallbackInterface != null)
            {
                @SelectTile.started -= m_Wrapper.m_PlayFieldActionsCallbackInterface.OnSelectTile;
                @SelectTile.performed -= m_Wrapper.m_PlayFieldActionsCallbackInterface.OnSelectTile;
                @SelectTile.canceled -= m_Wrapper.m_PlayFieldActionsCallbackInterface.OnSelectTile;
            }
            m_Wrapper.m_PlayFieldActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectTile.started += instance.OnSelectTile;
                @SelectTile.performed += instance.OnSelectTile;
                @SelectTile.canceled += instance.OnSelectTile;
            }
        }
    }
    public PlayFieldActions @PlayField => new PlayFieldActions(this);
    public interface IPlayFieldActions
    {
        void OnSelectTile(InputAction.CallbackContext context);
    }
}
