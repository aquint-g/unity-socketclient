using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginInputNavigation : MonoBehaviour
{
    public TMP_InputField UsernameInput; //0
    public TMP_InputField PasswordInput; //1

    public int InputSelected;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            InputSelected--;
            if(InputSelected < 0) InputSelected = 1;
            SelectInputField();

        }
        else if(Input.GetKeyDown(KeyCode.Tab))
        {
            InputSelected++;
            if (InputSelected > 1) InputSelected=0;
            SelectInputField();

        }

        void SelectInputField()
        {
            switch (InputSelected)
            {
                case 0: UsernameInput.Select();
                    break;
                case 1: PasswordInput.Select();
                    break;
            }
    }
   
}
 public void UsernameSelected(){
        InputSelected = 0;
    } 
    public void PasswordSelected(){
        InputSelected = 1;
    }
   
}