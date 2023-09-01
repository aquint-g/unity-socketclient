using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject connection;
    public GameObject loginButton;
    public GameObject loginInput;
    public GameObject passwordInput;
    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<Button>().onClick.AddListener(()=>print("clicked"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void InitiateLogin(){
        var login = loginInput.GetComponent<TMP_Text>().text;
        var password = passwordInput.GetComponent<TMP_Text>().text;
        var creds = new Credentials(){
            Username = login,
            Password = password
        };
        var message = new Message(){
            Code = "credentials",
            Args = creds // Pour faire l'inverse c'est FromJson() Obvious wsh
        };

        connection.GetComponent<Connection>().SendWebSocketMessage(JsonUtility.ToJson(message));
    }
}
