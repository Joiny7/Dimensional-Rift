using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HighScore : MonoBehaviour
{
	private int highScore;
    private int difficulty;
	public SwordScript sword;

	public int getHighScore () //Getter for sending HighScore to the UI
	{
		return highScore;
	}

    public String getDifficulty()
    {
        difficulty = DifficultyLevel.getDifficultyLevel();

        if (difficulty == 1) {
            return " (Tutorial)";
        }
        if (difficulty == 2)
        {
            return " (Easy)";
        }
        if (difficulty == 3)
        {
            return " (Normal)";
        }
        if (difficulty == 4)
        {
            return " (Hard)";
        }
        if (difficulty == 5)
        {
            return " (Insane)";
        }
        else {
            return " Diff N/A";
        }
    }

	public void Save ()         //Saves the highscore in binary to a .dat file
	{
		if (sword.getScore () > highScore) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/HighScore.dat");      //Create the save file on disk
	
			ScoreData data = new ScoreData ();
            data.highScore = sword.getScore();
            //data.difficulty = difficulty;

			bf.Serialize (file, data);
			file.Close ();
		}
	}

	public void Load ()         //Loads and decodes the binary file into the highScore variable
	{
		if (File.Exists (Application.persistentDataPath + "/HighScore.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/HighScore.dat", FileMode.Open); //Load the save file from disk
            ScoreData data = (ScoreData)bf.Deserialize (file);
			file.Close ();

			highScore = data.highScore;
            //difficulty = data.difficulty;
			//Debug.Log (Application.persistentDataPath); //Print save location to log
		}
	}
		
}

[Serializable]
class ScoreData //Serializable class for storing high score
{
    public int highScore;
    //public int difficulty;



    //Making an array?
    //public int[] highScore = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

    //Look for the index to insert score
    //	void checkHighScore (int score)
    //	{
    //		int i = 0;
    //		while (i < HighScore.Length) {
    //			if (HighScore [i] <= ScoreData) {
    //				break;
    //			}
    //			i++;
    //		}
    //		//Score doesn't make it to top 10
    //		if (i >= highScore.Length) {
    //			return -1;
    //		}
    //
    //		//Push all the scores not higher than score backward
    //		for (int j = highScore.Length - 1; j <= i; --j) {
    //			highScore [j] = highScore [j - 1];
    //		}
    //
    //		//Set Score:
    //		highScore [i] = score;
    //		return i;
    //	}
}