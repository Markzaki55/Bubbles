using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using System;

public class UI_InputHandler : MonoBehaviour, IInputHandler 
{
    Dictionary<string, IInput> _inputs = new Dictionary<string, IInput>();
    bool _isEnabled = true;
    Camera _camera;
    public static UI_InputHandler Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        AddInput("Touch", new TouchInput());
    }
    private void Start()
    {
        _camera = Camera.main;
    }
    public void TriggerInput(string key)
    {
        if (_inputs.TryGetValue(key, out IInput input))
        {
            input.InvokeInputState();
        }
    }
    public void AssignInputEvent(string key, Action inputEvent, InputState state)
    {
        if (!_inputs.TryGetValue(key, out IInput input))
        {
            return;
        }
        input.AddEvent(inputEvent, state);
    }
    public void AddInput(string key, IInput input)
    {
        if (!_inputs.ContainsKey(key))
        {
            _inputs.Add(key, input);
        }
    }
    private void Update()
    {
        UpdateInputs();
    }
    public void UpdateInputs()
    {
        if (!_isEnabled) return;
        foreach (var input in _inputs.Values)
        {
            input.UpdateInputState();
        }
    }

    public void SetInputState(bool state)
    {
        _isEnabled = state;
    }
}
