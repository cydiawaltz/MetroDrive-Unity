using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestoroy : MonoBehaviour
{
    private Thread pipeThread;
    private bool isRunning;
    private int receivedValue;
    private NamedPipeServerStream pipeServer;
    void Start()
    {
        //DontDestroyOnLoad(this);
        //pipeThread = new Thread(PipeListener);
        //pipeThread.Start();
        Screen.SetResolution(1280, 720, false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(SceneManager.GetActiveScene().name == "ver0.1")
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }*/
    }
    /*void PipeListener()
    {
        while (isRunning)
        {
            using (pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
            {
                try
                {
                    pipeServer.WaitForConnection();
                    if (!isRunning) return;

                    using (StreamReader reader = new StreamReader(pipeServer))
                    {
                        string message = reader.ReadLine();
                        if (int.TryParse(message, out receivedValue))
                        {
                            Debug.Log("Received value: " + receivedValue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (isRunning) // Only log the error if the server is running
                    {
                        Debug.LogError("PipeListener Error: " + ex.Message);
                    }
                }
            }
        }
    }*/
    private void OnApplicationQuit()
    {
        //Screen.SetResolution(1280, 720, false);
        /*isRunning = false;

        // Close the pipeServer to break the connection wait
        if (pipeServer != null && pipeServer.IsConnected)
        {
            pipeServer.Disconnect();
        }

        // Ensure the pipeServer is disposed
        pipeServer?.Dispose();

        // Wait for the listener thread to finish
        if (pipeThread != null && pipeThread.IsAlive)
        {
            pipeThread.Join();
        }*/
    }
}
