using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static string _path = "/savefile.json";
    static DataManager _instance;
    public static DataManager Instance
    {
        get { return _instance; }
    }

    public string playerName;
    public int bestScore;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    public class BestRecordData
    {
        public string name;
        public int score;
    }

    public void SaveData(int score)
    {
        if (score < bestScore) { return; }

        BestRecordData data = new BestRecordData();
        data.name = playerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + _path, json);
    }

    public BestRecordData LoadData()
    {
        string path = Application.persistentDataPath + _path;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            
            var data = JsonUtility.FromJson<BestRecordData>(json);
            bestScore = data.score;

            return data;
        }

        return null;
    }

    public string GetBestRecordString()
    {
        var data = LoadData();
        if (data != null)
        {
            return $"Best = {data.name} : {data.score}";
        }
        else
        {
            return playerName.Equals(string.Empty) ? "You're the first!" : $"Go, {playerName}!";
        }
    }
}
