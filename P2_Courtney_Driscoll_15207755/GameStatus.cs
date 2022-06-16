//Courtney Driscoll 15207755
//Code for scores

using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

    public static int EnemyScore;
    public static int PlayerScore;
    public static string EndMessage;
	// Use this for initialization
	void Start () {
        EnemyScore = 0;
        PlayerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if(PlayerScore >= 30){
            EndMessage = "YOU WIN";
        }
        else if(EnemyScore >= 30)
        {
            EndMessage = "YOU LOOSE";
        }

	}
}
