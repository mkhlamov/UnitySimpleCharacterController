//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputActions/PlayerInputActions.inputactions
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

namespace ITB
{
    public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""89baeb61-730d-4745-9156-316927b1fc49"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""bbed90ca-ca58-4668-97fe-97f3ba7f8784"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""937d792d-9e83-4b18-ae06-970776621150"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6976e06c-5cb1-40fc-b248-1ae298198ed7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""78bdf3dc-ba24-4bbb-a991-09bfcbc382c5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PrimaryShoot"",
                    ""type"": ""Button"",
                    ""id"": ""d1c4b1fd-df84-4dd4-b89e-8a57c793c14a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryShoot"",
                    ""type"": ""Button"",
                    ""id"": ""bcdafcbd-b060-4e56-aa66-d41a99f30887"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""aa0fedf8-e26b-4422-a1e2-98e7b55a6764"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""517f3e85-e1a1-4b01-86bc-582ab44ddf83"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2ce224a2-63c6-414d-9ce8-96c0ebc38626"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""80f1b5bc-b666-4c2d-b030-5af2bdb33d77"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c9d4daba-fbda-4231-9d23-738edc441c4f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d05ab653-a01f-4f44-9d4a-6d97cca2661b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d2dae4b-a82d-4fa1-8825-580719c3609d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6cb3e80-8833-4d50-b565-9a6e7cd95466"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2e59ba4-5a3c-44e3-8c7a-d64e55150ab0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1edd246f-f46c-4505-b2bb-45770d87e544"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryShoot"",
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
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_Accelerate = m_Player.FindAction("Accelerate", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
            m_Player_PrimaryShoot = m_Player.FindAction("PrimaryShoot", throwIfNotFound: true);
            m_Player_SecondaryShoot = m_Player.FindAction("SecondaryShoot", throwIfNotFound: true);
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
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_Accelerate;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Look;
        private readonly InputAction m_Player_PrimaryShoot;
        private readonly InputAction m_Player_SecondaryShoot;
        public struct PlayerActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @Accelerate => m_Wrapper.m_Player_Accelerate;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Look => m_Wrapper.m_Player_Look;
            public InputAction @PrimaryShoot => m_Wrapper.m_Player_PrimaryShoot;
            public InputAction @SecondaryShoot => m_Wrapper.m_Player_SecondaryShoot;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Accelerate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerate;
                    @Accelerate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerate;
                    @Accelerate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerate;
                    @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @PrimaryShoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryShoot;
                    @PrimaryShoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryShoot;
                    @PrimaryShoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryShoot;
                    @SecondaryShoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondaryShoot;
                    @SecondaryShoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondaryShoot;
                    @SecondaryShoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondaryShoot;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Accelerate.started += instance.OnAccelerate;
                    @Accelerate.performed += instance.OnAccelerate;
                    @Accelerate.canceled += instance.OnAccelerate;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @PrimaryShoot.started += instance.OnPrimaryShoot;
                    @PrimaryShoot.performed += instance.OnPrimaryShoot;
                    @PrimaryShoot.canceled += instance.OnPrimaryShoot;
                    @SecondaryShoot.started += instance.OnSecondaryShoot;
                    @SecondaryShoot.performed += instance.OnSecondaryShoot;
                    @SecondaryShoot.canceled += instance.OnSecondaryShoot;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnAccelerate(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnPrimaryShoot(InputAction.CallbackContext context);
            void OnSecondaryShoot(InputAction.CallbackContext context);
        }
    }
}
