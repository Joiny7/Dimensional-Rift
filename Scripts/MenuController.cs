using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{

    private string playerName = "Anonymous";
    private string score = "";
    List<Scores> highscore;
    public SwordScript sword;
    public PlayerScript player;

    // Use this for initialization
    void Start()
    {
        //EventManager._instance._buttonClick += ButtonClicked;

        highscore = new List<Scores>();

    }


    void ButtonClicked(GameObject _obj)
    {
        print("Clicked button:" + _obj.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name :");
        //name = GUILayout.TextField(name);
        //name = "PlayerName";
        name = player.getName();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Score :");
        //score = GUILayout.TextField(score);
        score = sword.getScore().ToString();
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Add Score"))
        {
            HighScoreManager._instance.SaveHighScore(name, System.Int32.Parse(score));
            highscore = HighScoreManager._instance.GetHighScore();
        }

        if (GUILayout.Button("Get LeaderBoard"))
        {
            highscore = HighScoreManager._instance.GetHighScore();
        }

        if (GUILayout.Button("Clear Leaderboard"))
        {
            HighScoreManager._instance.ClearLeaderBoard();
        }

        GUILayout.Space(60);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name", GUILayout.Width(Screen.width / 2));
        GUILayout.Label("Scores", GUILayout.Width(Screen.width / 2));
        GUILayout.EndHorizontal();

        GUILayout.Space(25);

        foreach (Scores _score in highscore)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(_score.name, GUILayout.Width(Screen.width / 2));
            GUILayout.Label("" + _score.score, GUILayout.Width(Screen.width / 2));
            GUILayout.EndHorizontal();
        }
    }
}