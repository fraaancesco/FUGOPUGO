using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
public class ScoreManager : MonoBehaviour
{
    private ScoreData scoredata;
    

    public ScoreData getScoreData()
    {
        return scoredata;
    }

    private void Awake()
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
        bool checkPlayer = false;
        foreach (Score item in scoredata.scores)
        {
           // Debug.Log("name : " + item.name + "score" + item.score);
          
            if (item.name == score.name && item.score < score.score)
            {
                item.score = score.score;
                checkPlayer = true;
                
            }
            
        }
        if(checkPlayer == false)
             scoredata.scores.Add(score);


    }

    // Save the score
    public void SaveScore()
    {
            string path = Path.Combine(Application.persistentDataPath, "Scoreboard.json");
            var json = JsonUtility.ToJson(scoredata, true); 
            File.WriteAllText(path, json);
    }

    public ScoreData LoadScoreboard()
    {
        string path = Path.Combine(Application.persistentDataPath, "Scoreboard.json");
        if (File.Exists(path) is true)
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<ScoreData>(json);
        }
        else if (!File.Exists(path))
        {
            scoredata = new ScoreData();
            SaveScore();
        }
        return scoredata;
    }
}
