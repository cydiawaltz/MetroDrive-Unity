using UnityEngine;
using UnityEngine.SceneManagement;
using UnityNamedPipe;

public class WaitForBve : MonoBehaviour
{
    //NamedPipeServerStream pipeServer;
    //CancellationTokenSource cts;    public bool isTest;
    //UnityNamedPipeà⁄çså„
    public NamedPipeClient client;
    public string sharedMes;
    public float timeoutSec;
    public bool isTest;

    /*void Start()
    {
        client = new NamedPipeClient();
        client.ReceivedEvent += Received;
        client.Start("MetroPipe");
    }*/
    async void Update()
    {
        /*if(sharedMes == "hi")
        {
            await client.SendCommandAsync(new PipeCommands.SendMessage { Message = "hello" });
        }
        switch(sharedMes)
        {
            case "hi":
                await client.SendCommandAsync(new PipeCommands.SendMessage { Message = "hello" });
                sharedMes = "notset";
            break;
            case "ready":
                Screen.SetResolution(Screen.width, Screen.height, true);
                this.gameObject.SetActive(false);
            break;
        }*/
        if(timeoutSec < 0f)
        {
            //if (isTest)
            //{
                this.gameObject.SetActive(false);
                //Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
            //}
            /*else
            {

                SceneManager.LoadScene("Trouble");
            }*/

        }
        else
        {
            timeoutSec -= Time.deltaTime;
        }
    }

    /*void Received(object sender,DataReceivedEventArgs e)
    {
        if (e.CommandType == typeof(PipeCommands.SendMessage))
        {
            var d = (PipeCommands.SendMessage)e.Data;
            sharedMes = d.Message;
        }
    }
    private void OnDestroy()
    {
        client.ReceivedEvent -= Received;
        client.Stop();
    }*/
}
