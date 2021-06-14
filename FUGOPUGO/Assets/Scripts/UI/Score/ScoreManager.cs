using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
public class ScoreManager : MonoBehaviour
{
    private ScoreData scoredata;
    private string path = "Assets/Json/Scoreboard.json";

    public ScoreData getScoreData()
    {
        return scoredata;
    }
    void Awake()
    {
        scoredata = LoadScoreboard(); 
    }

    public IEnumerable<Score> GetHighScores()
    {
        return scoredata.scores.OrderByDescending(keySelector: x => x.score);
        //return scoredata.scores.OrderByDescending( keySelector x :Score => x.score);
    }

    public void AddScore(Score score)
    {
        scoredata.scores.Add(score);
    }

    // Save the score
    public void SaveScore()
    {
        var json = JsonUtility.ToJson(scoredata, true);
        File.WriteAllText(path, json);
    }

    public ScoreData LoadScoreboard()
    {
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<ScoreData>(json);
    }
}
