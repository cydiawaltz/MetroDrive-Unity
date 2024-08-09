using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bvelauncher : MonoBehaviour
{
    private Thread pipeThread;
    private NamedPipeServerStream pipeServer;
    public int num;
    public MenuCounter counter;
    bool isChangeScene = false;
    bool isError = false;
    private void Start()
    {
    }
    private void Update()
    {
        num = counter.currentNum;
        if(Input.GetKeyDown(KeyCode.Return))
        {
            pipeThread = new Thread(PipeListener);
            pipeThread.Start();
        }
        if(isChangeScene)
        {
            SceneManager.LoadScene("wait");
            isChangeScene = !isChangeScene;
        }
        if(isError)
        {
            SceneManager.LoadScene("Trouble");
            isError = !isError;
        }
    }
    void PipeListener()
    {
            using (pipeServer = new NamedPipeServerStream("utob", PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(pipeServer))
                    {
                        writer.WriteLine(num.ToString());
                        writer.Flush();//BVE側に読み込むシナリオの番号を伝達
                    isChangeScene = true;
                }
                }
                catch (Exception ex)
                {
                UnityEngine.Debug.Log(ex.Message);
                isError |= true;
                }
            }
    }
    private void OnDestroy()
    {
        if (pipeServer != null && pipeServer.IsConnected)
        {
            pipeServer.Disconnect();
            pipeServer.Close();
        }

        if (pipeThread != null && pipeThread.IsAlive)
        {
            pipeThread.Join();
        }
    }
}
