using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;

    string [] level1Passwords = { "toy","cat","dog","food","pet" };
    string[] level2Passwords = { "florida", "notes", "gatorade", "pencil", "backpack" };
    string[] level3Passwords = { "jam-session", "amplification", "treble", "headphones", "microphone" };

    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Ready to Hack?");
        Terminal.WriteLine("Press 1 for Pet Store");
        Terminal.WriteLine("Press 2 for UF");
        Terminal.WriteLine("Press 3 for Music Store");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // always have option to go to main menu
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }else if(currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
    }


    void RunMainMenu(string input)
    {
        bool isValidLevelNum = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNum) {
            level = int.Parse(input);
            StartGame();

        }else if (input == "Mrs.Washington") {
            Terminal.WriteLine("MRS.MURRRPHHHYYYY");
        } else {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
        Terminal.WriteLine("Enter Your Password, hint: " + password.Anagram());
    }

    private void checkPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Try Again");
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("You Win");
        rewardImage();
        Terminal.WriteLine("You may type menu at any time");

    }

    private void rewardImage()
    {
        switch(level){
            case 1:
                Terminal.WriteLine(@"
   |\_/|                  
     | @ @   Woof! 
     |   <>              _  
     |  _/\------____ ((| |))
     |               `--' |   
 ____|_       ___|   |___.' 
/_/_____/____/_______|

You're in the Pet Store
"
                );
                break;
            case 2:
                Terminal.WriteLine(@"

| |  | | |-----
| |  | | |-----
| \  / | |
|______| |

You're in the big cheese (UF)
"
                 );
                break;
            case 3:
                Terminal.WriteLine(@"



     ; 
     ;;
     ;';.
     ;  ;;
     ;   ;;
     ;    ;;
     ;    ;;
     ;   ;'
     ;  ' 
,;;;,; 
;;;;;;
`;;;;'

You've got the beat
"
                 );
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
