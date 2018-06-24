using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    float Score;



    //game manager has aa reference to AIManager and levelManager.
    LevelManager levelManagerRef;
    AIManager aiManagerRef;



    bool addOnce = false;
    bool addOnce2 = false;
    public int gameState = 0;

    //60 seconds for each level so far
    float RoadLevelTime = 60;
    float ForestLevelTime = 60;

    //temp state amount
    int stateAmounts = 2;
    // Use this for initialization
    void Start () {
        Score = 0;
        levelManagerRef = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        aiManagerRef = GameObject.Find("AIManager").GetComponent<AIManager>();

    }
	
	// Update is called once per frame
	void Update () {
        Score += Time.deltaTime;
        //Debug.Log(Score);
        
        stateController();
        //aiManagerRef.setTotalLevelTime(RoadLevelTime);
    }

    //here for now.
    void stateController()
    {

        if (Score > RoadLevelTime)
        {
            if (!addOnce)
            {
                gameState++;
                gameState %= stateAmounts;
                //levelManagerRef.increaseLevelState();
                //changes the levels being spawned
                levelManagerRef.setLevelState(gameState);
                //changes the smart enemies
                aiManagerRef.setLevelState(gameState);
                
                addOnce = true;
            }
        }

    }

}
