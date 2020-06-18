using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExampleListener : MonoBehaviour
{
    public ButtonHandler primaryAxisClickHandler = null;
    public AxisHandler2D primaryAxisHanlder = null;
    public AxisHandler triggerHandler = null;

    public void OnEnable()
    {
        primaryAxisClickHandler.OnButtonDown += PrintPrimaryButtonDown;
        primaryAxisClickHandler.OnButtonUp += PrintPrimaryButtonUp;
        primaryAxisHanlder.OnValueChange += PrintPrimaryAxis;
        triggerHandler.OnValueChange += PrintTrigger;
    }

    public void OnDisable()
    {
        primaryAxisClickHandler.OnButtonDown -= PrintPrimaryButtonDown;
        primaryAxisClickHandler.OnButtonUp -= PrintPrimaryButtonUp;
        primaryAxisHanlder.OnValueChange -= PrintPrimaryAxis;
        triggerHandler.OnValueChange -= PrintTrigger;
    }

    private void PrintPrimaryButtonDown(XRController controller)
    {
        print("Primary button down");
    }

    private void PrintPrimaryButtonUp(XRController controller)
    {
        print("Primary button up");
    }

    private void PrintPrimaryAxis(XRController controller, Vector2 value)
    {
        print("Primary axis: " + value);
    }

    private void PrintTrigger(XRController controller, float value)
    {
        print("Trigger: " + value);
    }
}
