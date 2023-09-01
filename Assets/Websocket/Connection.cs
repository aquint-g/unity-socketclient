using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using NativeWebSocket;

public struct Message
{
    public string Code;
    public object Args;
    public string CredentialsId;
}
public struct Credentials
{
  public string Username;
  public string Password;
}


public class Connection : MonoBehaviour
{

  public WebSocket websocket;

  // Start is called before the first frame update
  async void Start()
  {
    
    websocket = new WebSocket("ws://localhost:8080");

    websocket.OnOpen += () =>
    {
      Debug.Log("Connection open!");
    };

    websocket.OnError += (e) =>
    {
      Debug.Log("Error! " + e);
    };

    websocket.OnClose += (e) =>
    {
      Debug.Log("Connection closed!");
    };

    websocket.OnMessage += (bytes) =>
    {
      Debug.Log("OnMessage!");
      Debug.Log(bytes);

      // getting the message as a string
      // var message = System.Text.Encoding.UTF8.GetString(bytes);
      // Debug.Log("OnMessage! " + message);
    };

    // Keep sending messages at every 0.3s
    //InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

    // waiting for messages
    await websocket.Connect();
  }

  void Update()
  {
    #if !UNITY_WEBGL || UNITY_EDITOR
      websocket.DispatchMessageQueue();
    #endif
  }

  public async void SendWebSocketMessage(string message)
  {
    if (websocket.State == WebSocketState.Open)
    {
      // Sending bytes
      await websocket.SendText(message);
    }
  }

  private async void OnApplicationQuit()
  {
    await websocket.Close();
  }
}