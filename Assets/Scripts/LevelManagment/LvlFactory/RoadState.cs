using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadState : IState {


    private int startPull;
	// Use this for initialization
	void Start () {
        levelList = new List<GameObject>();
        myFactory = GameObject.Find("ObsticalFactory").GetComponent<RoadObsticalFactory>();
        startPull = 0;
    }
	
    public override void endState()
    {
        //IMPORTANT call this endState when u switch states.
        pullCount = 0;
    }

    public override void addLevel(GameObject inLvl)
    {
        levelList.Add(inLvl);
    }


    public override GameObject returnLevel()
    {
        if (pullCount == 0 && startPull > 0)
        {
            Debug.Log("initial trasition");
            pullCount++;
            
            buildLevel = levelList[0];

            levelObsticalSheet = myFactory.returnObsticalSheet();

            //levelObsticalSheet.SetActive(true);
            buildLevel.GetComponent<Level>().setObsticalSheet(levelObsticalSheet);
                
            
            levelObsticalSheet.transform.position = buildLevel.transform.position;

            return buildLevel;
        }
        else
        {
            randomPoolInt = UnityEngine.Random.Range(1, levelList.Count);
            while (levelList[randomPoolInt].activeInHierarchy)
            {
                randomPoolInt = UnityEngine.Random.Range(1, levelList.Count);
            }
            pullCount++;
            startPull++;
            buildLevel = levelList[randomPoolInt];
  

            levelObsticalSheet = myFactory.returnObsticalSheet();

            buildLevel.GetComponent<Level>().setObsticalSheet(levelObsticalSheet);

            //levelObsticalSheet.SetActive(true);
            //levelObsticalSheet.transform.position = buildLevel.transform.position;

            return buildLevel;
        }
    }

    //public override void setLevelInactive()
    //{
    //    buildLevel.SetActive(false);
    //}


 


}
