using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ScoreUI : MonoBehaviour
{
    public RowUI RowUI;
    public ScoreManager scoreManager;
     void Start()
    {
        scoreManager.LoadScoreboard();
        if (scoreManager.getScoreData().scores.Count != 0)
        {
            var scores = scoreManager.GetHighScores().ToArray(); //ordino gli scores
            for (int i = 0; i < scores.Length; i++)  //per tutti uso scores.Length
            {
                if (scores[i].name != ""  && i<10 ) 
                {
                    var row = Instantiate(RowUI, transform).GetComponent<RowUI>();
                    row.rank.text = (i + 1).ToString();
                    row.namePlayer.text = scores[i].name;
                    row.scorePlayer.text = scores[i].score.ToString();
                }
                
            }
        }
    }
}
