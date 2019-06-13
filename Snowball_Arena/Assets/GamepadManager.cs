using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GamepadManager : MonoBehaviour
{
    private string[] inputData = new string[] {"HorizontalJoy", "VerticalJoy", "TriggerJoy" ,"LeftBumperJoy", "RightBumperJoy", "HorizontalTargetJoy", "VerticalTargetJoy" };
    private KeyCode[] joystickStartArray = { KeyCode.Joystick1Button7, KeyCode.Joystick2Button7, KeyCode.Joystick3Button7, KeyCode.Joystick4Button7 };
    [SerializeField]private List<KeyCode> joystickAlreadyInArray;
    public string[,] assignedJoystickButton{get;set;}
    private int currentPlayer = 0;
    private void Awake() {
        assignedJoystickButton = new string[GameManager.Instance.playerNumber,7];
        joystickAlreadyInArray = new List<KeyCode>();
    }
    private void FixedUpdate()
    {
        GetJoystickNumber();
    }
    private void GetJoystickNumber(){
        foreach (KeyCode keystart in joystickStartArray)
        {
            if (Input.GetKeyDown(keystart) && (currentPlayer == 0 || !CheckIfInArray(keystart)))
            {
                Debug.Log(keystart.ToString().Substring(8,1));
                joystickAlreadyInArray.Add(keystart);
                string tmpJoystickButton = keystart.ToString().Substring(8,1);
                for(int i = 0; i<7;i++){
                    assignedJoystickButton[currentPlayer,i] = inputData[i] + tmpJoystickButton;
                }
                Debug.Log(keystart.ToString());
                currentPlayer++;
                if(currentPlayer == assignedJoystickButton.GetLength(0)){
                    KeyCodeSave.Instance.joystickKeyCodeSaved = assignedJoystickButton;
                    SceneManager.LoadScene("test");
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
