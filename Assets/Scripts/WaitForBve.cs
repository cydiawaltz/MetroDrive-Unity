using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class WaitForBve : MonoBehaviour
{ 
    private async void Start()
    {
        //string exepath = Path.Combine(Application.dataPath, "../Apps/BveTs/Scenario/base.bat");
        //Process.Start(exepath);

        using (var pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut))
        {
            var cts = new CancellationTokenSource();
            var task = pipeServer.WaitForConnectionAsync(cts.Token);

            if (await Task.WhenAny(task, Task.Delay(22000)) == task)
            {
                // Connection established within 22 seconds
                try
                {
                    using (var reader = new StreamReader(pipeServer))
                    {
                        while (pipeServer.IsConnected)
                        {
                            var str = await reader.ReadLineAsync();
                            if (str == "ready")
                            {
                                this.gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    this.gameObject.SetActive(false);
                    UnityEngine.Debug.Log(e.Message);
                }
            }
            else
            {
                // Timeout
                cts.Cancel();
                this.gameObject.SetActive(false);
            }
        }
    }

}
