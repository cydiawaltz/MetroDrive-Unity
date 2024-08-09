using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Text;
using UnityEngine;

public class waiting : MonoBehaviour
{
    bool isEnd;
    bool isclear;
    bool isover;
    public GameObject clear;
    public GameObject gameover;
    private void Start()
    {
        Pipe();
    }
    private void Update()
    {
        if(isclear)
        {
            clear.SetActive(true);
            gameover.SetActive(false);
        }
        if(isover)
        {
            clear.SetActive(false);
            gameover.SetActive(true);
        }
    }
    async void Pipe()
    {
        using (var pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut))
        {
            await pipeServer.WaitForConnectionAsync();
            try
            {
                using (var reader = new StreamReader(pipeServer, Encoding.UTF8))
                {
                    while (true)
                    {
                        string message = await reader.ReadLineAsync();
                            if(isEnd)
                            {
                                using (StreamWriter writer = new StreamWriter(pipeServer))
                                {
                                    writer.WriteLine("end");
                                    writer.Flush();
                                }
                            }
                            if(message == "sEndonClear")//scenario End on Clear�̗��B�S��ԑ��j��
                        {
                            isclear = true;
                        }
                        if (message == "sEndonGO")//scenario End on GameOver�̗��B�Q�[���I�[�o�[��
                        {
                            isover = true;
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Debug.Log("���O�t���p�C�v�ʐM�ŃG���[���������܂����B" + ex.Message);
            }
        }
    }
    private void OnApplicationQuit()
    {
        isEnd = true;
    }
}
