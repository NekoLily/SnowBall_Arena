using System.Collections;
using System.Collections.Generic;

public class KeyCodeSave
{
    public string[,] joystickKeyCodeSaved{get;set;}
    private static KeyCodeSave _instance;
    public static KeyCodeSave Instance{
        get{
            if (_instance==null)
            {
                _instance = new KeyCodeSave();
            }
            return _instance;
        }
    }
    public string[] GiveOneDimension(int playerNumber){
        string[] tmpString = new string[7];
        for(int i = 0; i <7;i++){
            tmpString[i] = joystickKeyCodeSaved[playerNumber,i];
        }
    }
}
