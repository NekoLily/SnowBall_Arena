using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadManager : MonoBehaviour
{
    string[] InputData = new string[] {"HorizontalJoy", "VerticalJoy", "TriggerJoy" ,"LeftBumperJoy", "RightBumperJoy", "HorizontalTargetJoy", "VerticalTargetJoy" };
    KeyCode[] JoystickStartArray = { KeyCode.Joystick1Button7, KeyCode.Joystick2Button7, KeyCode.Joystick3Button7, KeyCode.Joystick4Button7 };

    private void FixedUpdate()
    {
        int i = 0;
        foreach (KeyCode Keystart in JoystickStartArray)
        {
            if (Input.GetKeyDown(Keystart))
            {
                
            }
            i++;
        }
    }
}
