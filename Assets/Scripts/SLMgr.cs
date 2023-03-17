using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// 유저 정보
class PlayerName
{
    public string playerName;

    public PlayerName(string playerName)
    {
        this.playerName = playerName;
    }
}

public class SLMgr : MonoBehaviour
{
    public Text tx;
    List<PlayerName> data = new List<PlayerName>();

    private void Start()
    {
        //data.Add(new PlayerName("Mosia"));
    }

    public void _save()
    {
        string jdata = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", jdata);
    }

    public void _load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        tx.text = jdata;
        data = JsonUtility.FromJson<List<PlayerName>>(jdata);
        print(data[0].playerName);
    }
}
