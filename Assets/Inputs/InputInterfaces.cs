using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
    public enum InputState
    {
        None, Held, Released, Pressed
    }
    /// <summary>
    /// Interface that handles all sorts of inputs and assigns events to them
    /// </summary>
    public interface IInputHandler
    {
        void TriggerInput(string key);
        void AddInput(string key, IInput input);
        void AssignInputEvent(string key, Action inputEvent, InputState state);
        void UpdateInputs();
        void SetInputState(bool state);
    }
    /// <summary>
    /// Interface that should be implemented by one input type.
    /// Depending on state, will fire off an event that return the Input value as an object (make sure to cast it)
    /// </summary>
    public interface IInput
    {
        InputState State { get; }
        void InvokeInputState();
        void AddEvent(Action inputEvent, InputState state);
        void UpdateInputState();
        event Action PressedInput;
        event Action HeldInput;
        event Action ReleasedInput;
    }
}