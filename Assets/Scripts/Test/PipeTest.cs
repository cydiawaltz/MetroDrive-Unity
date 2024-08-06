using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using UnityEngine;

public class PipeTest : MonoBehaviour
{
    private Thread pipeThread;
    private bool isRunning = true;
    private int receivedValue;
    private NamedPipeServerStream pipeServer;

    void Start()
    {
        pipeThread = new Thread(PipeListener);
        pipeThread.Start();
    }

    void PipeListener()
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
    }

    void OnApplicationQuit()
    {
        isRunning = false;

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
        }
    }

    void Update()
    {
        // Use the received value in the Unity update loop
        Debug.Log("Current received value: " + receivedValue);
    }
}
