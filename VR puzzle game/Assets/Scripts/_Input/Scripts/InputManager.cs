﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InputManager : MonoBehaviour
{
    public List<ButtonHandler> allButtonHandlers = new List<ButtonHandler>();
    public List<AxisHandler> allAxisHandlers = new List<AxisHandler>();
    public List<AxisHandler2D> allAxisHandlers2D = new List<AxisHandler2D>();

    private XRController controller = null;
    private void Awake()
    {
        controller = GetComponent<XRController>();
    }

    private void Update()
    {
        HandleButtonEvents();
        HandleAxis2DEvents();
        HandleAxisEvents();
    }

    private void HandleButtonEvents()
    {
        foreach(ButtonHandler handler in allButtonHandlers)   
            handler.HandleState(controller);
     
    }

    private void HandleAxis2DEvents()
    {
        foreach (AxisHandler2D handler in allAxisHandlers2D)
            handler.HandleState(controller);
    }

    public void HandleAxisEvents()
    {
        foreach (AxisHandler handler in allAxisHandlers)
            handler.HandleState(controller);
    }
}

