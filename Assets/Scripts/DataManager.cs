using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string PlayerName;
    public int Highscore;
    public string HighscorePlayer;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [Serializable]
    class PersistentData {
        public int Highscore;
        public string PlayerName;

        public PersistentData(int highscore, string playerName) {
            Highscore = highscore;
            PlayerName = playerName;
        }
    }

    public void SaveData() {
        string dataToSave = JsonUtility.ToJson(new PersistentData(Highscore, PlayerName));
        File.WriteAllText(Application.persistentDataPath + "./saveFile.json", dataToSave);
    }

    public void LoadData() {
        if (File.Exists(Application.persistentDataPath + "./saveFile.json")) {
            PersistentData data = JsonUtility.FromJson<PersistentData>(File.ReadAllText(Application.persistentDataPath + "./saveFile.json"));
            Highscore = data.Highscore;
            HighscorePlayer = data.PlayerName;
        }
    }
}
