using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForBve : MonoBehaviour
{
    NamedPipeServerStream pipeServer;
    CancellationTokenSource cts;
    public int timeoutsec;
    public bool isTest;

    private async void Start()
    {
        try
        {
            string pipeName = "btou";
            string exepath = Path.Combine(Application.dataPath, "../Apps/BveTs/base.bat");

            // �p�C�v�T�[�o�[���쐬
            pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut);

            // �o�b�`�t�@�C�����N��
            Process.Start(exepath);

            cts = new CancellationTokenSource();
            var connectTask = pipeServer.WaitForConnectionAsync(cts.Token);

            // �^�C���A�E�g���Ԃ�ݒ�i40sec�j
            var timeoutTask = Task.Delay(timeoutsec);

            // �^�C���A�E�g�܂ł̒Z������ҋ@
            var completedTask = await Task.WhenAny(connectTask, timeoutTask);

            if (completedTask == timeoutTask)
            {
                // �^�C���A�E�g�����ꍇ
                throw new TimeoutException("�^�C���A�E�g���܂����B(mes from script)");
            }

            // �ڑ����m�����ꂽ�ꍇ
            using (var reader = new StreamReader(pipeServer))
            {
                while (pipeServer.IsConnected)
                {
                    var str = await reader.ReadLineAsync();
                    if (str == "ready")
                    {
                        Screen.SetResolution(Screen.width, Screen.height, true);
                        this.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log("Exception Message: " + e.Message);
            if(isTest)
            {
                this.gameObject.SetActive(false);
                //Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
            }
            else
            {
                SceneManager.LoadScene("Trouble");
            }
        }
    }

    private void OnDestroy()
    {
        try
        {
            cts?.Cancel();
            pipeServer?.Disconnect();
            pipeServer.Dispose();
            var timeoutTask = Task.Delay(timeoutsec);
        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log("Exception during OnDestroy: " + e.Message);
        }
    }
    private void OnApplicationQuit()
    {
        try
        {
            cts?.Cancel();
            pipeServer?.Disconnect();
            pipeServer.Dispose();
        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log("Exception during On AppQuit: " + e.Message);
        }
    }
}
