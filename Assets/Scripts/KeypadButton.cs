using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public string value;     // e.g. "1", "2", "Enter", "Clear"
    public Keypad keypad;    // drag the Keypad parent here

    void OnMouseDown()   // called when player clicks with mouse
    {
        if (value == "Enter") keypad.Enter();
        else if (value == "Clear") keypad.ClearInput();
        else keypad.PressNumber(value);
    }
}
