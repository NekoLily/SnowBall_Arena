using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadManager : MonoBehaviour
{
    private string[] inputData = new string[] {"HorizontalJoy", "VerticalJoy", "TriggerJoy" ,"LeftBumperJoy", "RightBumperJoy", "HorizontalTargetJoy", "VerticalTargetJoy" };
    private KeyCode[] joystickStartArray = { KeyCode.Joystick1Button7, KeyCode.Joystick2Button7, KeyCode.Joystick3Button7, KeyCode.Joystick4Button7 };
    private List<KeyCode> joystickAlreadyInArray;
    public string[,] assignedJoystickButton{get;set;}
    private int currentPlayer = 0;
    private void Awake() {
        assignedJoystickButton = new string[/*numberOfPlayer*/4,7];
    }
    private void FixedUpdate()
    {
        GetJoystickNumber();
    }
    private void GetJoystickNumber(){
        foreach (KeyCode keystart in joystickStartArray)
        {
            if (Input.GetKeyDown(keystart) && !CheckIfInArray(keystart))
            {
                joystickAlreadyInArray.Add(keystart);
                string tmpJoystickButton = keystart.ToString().Substring(17,1);
                for(int i = 0; i<7;i++){
                    assignedJoystickButton[currentPlayer,i] = inputData[i] + tmpJoystickButton;
                }
                currentPlayer++;
                if(currentPlayer == assignedJoystickButton.GetLength(1)){
                    
                }
            }
        }
    }

    private bool CheckIfInArray(KeyCode inputtedKeyCode){
        foreach(var joystick in joystickAlreadyInArray){
            if(inputtedKeyCode == joystick){
                return true;
            }
        }
        return false;
    }
}
