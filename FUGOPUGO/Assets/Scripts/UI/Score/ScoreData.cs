using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData 
{
    public List<Score> scores;

    public ScoreData()
    {
        scores = new List<Score>();
    }
}
[System.Serializable]
public class Score
{
    public string name;
    public double score;

    public Score(string name, double score)
    {
        this.name = name;
        this.score = score;
    }
}
