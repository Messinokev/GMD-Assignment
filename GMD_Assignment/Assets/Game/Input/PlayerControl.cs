//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Game/Input/PlayerControl.inputactions
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

public partial class @PlayerControl : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e9b6e9c9-dbc9-45f6-b73b-beccec9bbb97"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8d12d810-d1c3-492b-a073-9b78fae77f7a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c5d353e7-c029-4d6c-9c45-7c846060a0f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""0e9754a9-e11d-4cd4-8156-dd4b07e15c8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SceneLoad"",
                    ""type"": ""Button"",
                    ""id"": ""0f2a3a20-416a-4137-b841-3aa537e62e55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UsePotion"",
                    ""type"": ""Button"",
                    ""id"": ""5d0c1bf0-fd00-4b47-bd4b-742df183f4f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ContinueDialog"",
                    ""type"": ""Button"",
                    ""id"": ""6d3da269-e840-4397-ad7b-71d63e75343d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoping"",
                    ""type"": ""Button"",
                    ""id"": ""2bdb084b-21f8-48b2-b1bf-7ecb6373078e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LoadSaving"",
                    ""type"": ""Button"",
                    ""id"": ""7a8e00e1-ec6a-4387-ae74-8a447fe956b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""b68bcd86-967b-4757-a953-13ef48820907"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""18447bcc-56b4-43a8-8141-aefe5f99b4eb"",
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
                    ""id"": ""12d4e39e-0456-44f2-8c16-3ce6913268b3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""976d9ca2-18d9-4353-b794-ce4e48cd8409"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5dd8c226-c652-43fe-ba81-db49cee628f4"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""69984475-0ef2-444d-adf9-9af4466cb4f2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a927bd20-2b8a-4d06-ba90-1216a7b4bdba"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2eb97767-a834-4976-b1d8-1f7be979499f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5d066a81-b42c-4067-8195-a7ec5784a365"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""4f1080e6-1519-43dd-93f5-5d41a952566e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c2a52280-8e05-4fd0-9e53-0f47bff54dc1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0f8600db-1407-4116-9714-cd07c028d3f9"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""43b5fac6-c24a-425f-9d88-e6025b6b96ae"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""24e0c65a-15f7-4b1b-9876-1b241b9ec5d1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SceneLoad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2470eb7f-fd1b-4aa7-b23f-fb59857ad203"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SceneLoad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e20b3ab7-2bc2-4110-80ce-abc2e84bee4a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UsePotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5cace44-44a9-4834-82c9-7d61314da25b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UsePotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a63743bb-927c-4304-a6da-a44bf8cade31"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ContinueDialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84a94d87-87c3-44df-a08c-73e3860bfc8e"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ContinueDialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f97df25-3c3c-4296-952c-9e49e8e2c7cb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a3570cf-2a15-4de8-bb0b-848aa0aeaa81"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4b6e09d-69d9-4065-8552-e767c7d3f51b"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LoadSaving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03045897-8051-45bc-a9d5-bb591a32ddfb"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
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
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_SceneLoad = m_Player.FindAction("SceneLoad", throwIfNotFound: true);
        m_Player_UsePotion = m_Player.FindAction("UsePotion", throwIfNotFound: true);
        m_Player_ContinueDialog = m_Player.FindAction("ContinueDialog", throwIfNotFound: true);
        m_Player_Shoping = m_Player.FindAction("Shoping", throwIfNotFound: true);
        m_Player_LoadSaving = m_Player.FindAction("LoadSaving", throwIfNotFound: true);
        m_Player_SwitchWeapon = m_Player.FindAction("SwitchWeapon", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_SceneLoad;
    private readonly InputAction m_Player_UsePotion;
    private readonly InputAction m_Player_ContinueDialog;
    private readonly InputAction m_Player_Shoping;
    private readonly InputAction m_Player_LoadSaving;
    private readonly InputAction m_Player_SwitchWeapon;
    public struct PlayerActions
    {
        private @PlayerControl m_Wrapper;
        public PlayerActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @SceneLoad => m_Wrapper.m_Player_SceneLoad;
        public InputAction @UsePotion => m_Wrapper.m_Player_UsePotion;
        public InputAction @ContinueDialog => m_Wrapper.m_Player_ContinueDialog;
        public InputAction @Shoping => m_Wrapper.m_Player_Shoping;
        public InputAction @LoadSaving => m_Wrapper.m_Player_LoadSaving;
        public InputAction @SwitchWeapon => m_Wrapper.m_Player_SwitchWeapon;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @SceneLoad.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSceneLoad;
                @SceneLoad.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSceneLoad;
                @SceneLoad.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSceneLoad;
                @UsePotion.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePotion;
                @UsePotion.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePotion;
                @UsePotion.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePotion;
                @ContinueDialog.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnContinueDialog;
                @ContinueDialog.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnContinueDialog;
                @ContinueDialog.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnContinueDialog;
                @Shoping.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoping;
                @Shoping.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoping;
                @Shoping.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoping;
                @LoadSaving.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadSaving;
                @LoadSaving.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadSaving;
                @LoadSaving.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadSaving;
                @SwitchWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchWeapon;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @SceneLoad.started += instance.OnSceneLoad;
                @SceneLoad.performed += instance.OnSceneLoad;
                @SceneLoad.canceled += instance.OnSceneLoad;
                @UsePotion.started += instance.OnUsePotion;
                @UsePotion.performed += instance.OnUsePotion;
                @UsePotion.canceled += instance.OnUsePotion;
                @ContinueDialog.started += instance.OnContinueDialog;
                @ContinueDialog.performed += instance.OnContinueDialog;
                @ContinueDialog.canceled += instance.OnContinueDialog;
                @Shoping.started += instance.OnShoping;
                @Shoping.performed += instance.OnShoping;
                @Shoping.canceled += instance.OnShoping;
                @LoadSaving.started += instance.OnLoadSaving;
                @LoadSaving.performed += instance.OnLoadSaving;
                @LoadSaving.canceled += instance.OnLoadSaving;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSceneLoad(InputAction.CallbackContext context);
        void OnUsePotion(InputAction.CallbackContext context);
        void OnContinueDialog(InputAction.CallbackContext context);
        void OnShoping(InputAction.CallbackContext context);
        void OnLoadSaving(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
    }
}
