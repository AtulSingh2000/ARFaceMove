using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerGameOver : MonoBehaviour
{
    private UIManager UI;
    public GameObject GameOverPanel;
   
    public Text Score;
    public Text FinalScore;
    public Text Highscore;
    public static int ScoreCount;

    public static int HighScore;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        Vector3 tmpPos = transform.position;
        tmpPos.x = Mathf.Clamp(tmpPos.x, -1.8f, 1.8f);
        transform.position = tmpPos;

        ScoreCount = 0;
        HighScore = PlayerPrefs.GetInt("Highscore", HighScore);

        UI = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "SCORE: " + ScoreCount;

        if (ScoreCount > HighScore)
        {
            HighScore = ScoreCount;
            PlayerPrefs.SetInt("Highscore", HighScore);
        }

        Highscore.text = "HIGHSCORE: " + HighScore;
        FinalScore.text = "YOUR SCORE: " + ScoreCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
           // Debug.Log("Yes!!");
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
            //Time.timeScale = 0;

        }
        if(other.gameObject.CompareTag("Score"))
        {
            //GameWinPanel.SetActive(true);
            Debug.Log("Win");
            ScoreCount += 1;
        }
    }

   
    public void Restart()
    {

        UI.Restar();
    }
}

