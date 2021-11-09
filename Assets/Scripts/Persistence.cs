using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Persistence : MonoBehaviour
{
    public static Persistence Instance;

    public string highScoreName;
    public int highScore;
    public string playerName;
    public int playerScore;
    public Dictionary<string, int> players = new Dictionary<string, int>() { };

    [System.Serializable]
    class ScoreBoard
    {
        public string highName;
        public int saveScore;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScoreBoard();
    }

    public void AddPlayerScore(string name, int score)
    {
        if (players.ContainsKey(name))
        {
            players[name] = score;
        }
        else
        {
            players.Add(name, score);
        }
    }

    public void SavePlayerScore()
    {
        ScoreBoard board = new ScoreBoard();
        setHighScore();
        board.highName = highScoreName;
        board.saveScore = highScore;
        string json = JsonUtility.ToJson(board);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
        Debug.Log(Application.persistentDataPath + "/saveFile.json");

    }

    public void LoadScoreBoard()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string reverseJson = File.ReadAllText(path);
            ScoreBoard board = JsonUtility.FromJson<ScoreBoard>(reverseJson);
            highScoreName = board.highName;
            highScore = board.saveScore;
        }
    }
    public void setHighScore()
    {
        if(playerScore > highScore){
            highScore = playerScore;
            highScoreName = playerName;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"{this.playerName}:{this.playerScore}");
    }
}
