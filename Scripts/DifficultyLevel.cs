using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyLevel : MonoBehaviour {

	public static int difficulty = 3; //Normal difficulty by default

	public static int getDifficultyLevel() {
		return difficulty;
	}

	public static void setDifficultyLevel(int d) {
		difficulty = d;
	}
}
