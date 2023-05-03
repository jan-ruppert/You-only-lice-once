using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class implements the general abstract class of a tutorial state.
/// </summary>
public abstract class TutorialState : State
{
    [Header("GUI")]
    [SerializeField]
    /// <summary>
    /// Saves the tutorial dialogue.
    /// </summary>
    [TextArea]
    protected string[] text;

    public string[] Text {
        get{return text;}
    }

    [SerializeField]
    protected InputActionReference keyReference;
    /// <summary>
    /// Returns the name of the keybinding for the given InputActionReference for keyboard.
    /// If the InputActionReference is a composite of multiple bindings, it returns a composite string of them all.
    /// </summary>
    /// <value>String with the name of the key binding.</value>
    public string KeyText_Keyboard {
        get{
            if(keyReference != null) {
                var bindingIndex = keyReference.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard"));
                if(keyReference.action.bindings[0].isComposite) {
                    return InputManager.GetBindingName(keyReference.action.name, bindingIndex - 1);
                } else {
                    return InputManager.GetBindingName(keyReference.action.name, bindingIndex);
                }
            } else {
                return string.Empty;
            }
        }
    }

    /// <summary>
    /// Returns the name of the keybinding for the given InputActionReference for gamepad.
    /// </summary>
    /// <value>String with the name of the key binding</value>
    public string KeyText_Gamepad {
        get{
            if(keyReference != null) {
                return InputManager.GetBindingName(keyReference.action.name, keyReference.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad")));
            } else {
                return string.Empty;
            }
        }
    }
    
    /// <summary>
    /// Saves if the tutorial state is completed.
    /// </summary>
    protected bool done = false;

    public bool Done {get{return done;}}
    [SerializeField]
    protected GameObject description;
    /// <summary>
    /// Saves the following tutorial state.
    /// </summary>
    [SerializeField]
    protected TutorialState nextState;

    public TutorialState NextState() {
        return nextState;
    }
}
