using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    public void SaveFiles(string saveDetaName,string writeMes)
    {
        string path = Path.Combine(Application.dataPath, "../SaveData/" + saveDetaName);
        File.WriteAllText(path,writeMes);
    }
    public string LoadFiles(string saveDetaName)
    {
        string path = Path.Combine(Application.dataPath, "../SaveData/" + saveDetaName);
        string readDeta = File.ReadAllText(path);
        return readDeta;
    }
    public bool IsExists(string saveDetaName)
    {
        string path = Path.Combine(Application.dataPath, "../SaveData/" + saveDetaName);
        return File.Exists(path);
    }
}
