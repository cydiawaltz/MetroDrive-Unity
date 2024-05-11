using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    public void SaveFiles(string saveDetaName,string writeMes)//.txt‚ðŠÜ‚Ü‚È‚¢Œ`Ž®
    {
        string path = Path.Combine(Application.dataPath, "../SaveDeta/" + saveDetaName+".txt");
        File.WriteAllText(path,writeMes);
    }
    public string LoadFiles(string saveDetaName)
    {
        string path = Path.Combine(Application.dataPath, "../SaveDeta/" + saveDetaName + ".txt");
        string readDeta = File.ReadAllText(path);
        return readDeta;
    }
}
