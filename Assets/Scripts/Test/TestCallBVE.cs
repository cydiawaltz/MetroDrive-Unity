using UnityEngine;
using System.Diagnostics;
using System.IO;

public class RunBatFile : MonoBehaviour
{
    void CallBVE()
    {
        // アプリケーションの実行ファイルが存在するディレクトリを取得
        string directoryPath = Path.Combine(Application.dataPath,"../scripts/");

        // バッチファイルのパスを作成
        string batFilePath = Path.Combine(directoryPath, "Test.bat");

        // バッチファイルが存在するかを確認
        if (System.IO.File.Exists(batFilePath))
        {
            // バッチファイルを実行
            Process.Start(batFilePath);
        }
        else
        {
            UnityEngine.Debug.LogError("a.batファイルが見つかりませんでした。");
        }
    }
    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;

public class TestCallBVE : MonoBehaviour
{
    Process process;
    public string appPath = Path.Combine(Application.dataPath,"../scripts/Test.bat");
    public void CallBVE()
    {
        callBatFile();
    }
    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    private void callBatFile()
    {
        // 他のプロセスが実行しているなら行わない
        if (process != null) return;

        // 新規プロセスを作成し、batファイルのパスを登録
        process = new Process();
        process.StartInfo.FileName = appPath;

        // 外部プロセスを実行
        process.Start();
    }
}
*/