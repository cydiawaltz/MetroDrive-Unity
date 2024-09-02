using UnityEngine;
using UnityEngine.SceneManagement;
using UnityNamedPipe;

public class bvelauncher : MonoBehaviour
{
    //private Thread pipeThread;
    //private NamedPipeServerStream pipeServer;
    public int num;
    public MenuCounter counter;
    bool isChangeScene = false;
    bool isError = false;
    public string sceneName;
    //UnityNamedPipe移行後
    public NamedPipeClient client;
    public string sharedMes;

    private void Start()
    {
        client = new NamedPipeClient();
        client.ReceivedEvent += Received;
        client.Start("MetroPipe");
    }
    private async void Update()
    {
        num = counter.currentNum;
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //pipeThread = new Thread(PipeListener);
            //pipeThread.Start();
            await client.SendCommandAsync(new PipeCommands.SendMessage { Message = num.ToString() });
            SceneManager.LoadScene("wait");
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    void Received(object sender, DataReceivedEventArgs e)
    {
        if (e.CommandType == typeof(PipeCommands.SendMessage))
        {
            var d = (PipeCommands.SendMessage)e.Data;
            sharedMes = d.Message;
        }
    }
    void OnDestroy()
    {
        client.ReceivedEvent -= Received;
        client.Stop();
    }
    /*void PipeListener()
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
    }*/
}
