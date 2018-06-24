using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is the top level script in charge of 
//all things having to do with the levels spawing
//in the game.
public class LevelManager : MonoBehaviour {

    public static LevelManager levelManager;

    //levels pooled in game
    GameObject finishedLevels;
    GameObject rem;
    bool loadOnce = false;

    float buildingHeight = 0;
    GameObject top;
    public Vector3 temp;

    LevelBuffer levelBuffer;
    LevelFactory levelFactory;
    
    // Use this for initialization
    void Start () {

        levelManager = this;
        levelBuffer = this.GetComponent<LevelBuffer>();
        //levelFactory = this.GetComponent<LevelFactory>();
        levelFactory = GameObject.Find("LevelFactory").GetComponent<LevelFactory>();

        GameObject Lvl = GameObject.Find("StartLevel");

        if(Lvl != null)
        {
            buildingHeight = Lvl.transform.localScale.y;
            Debug.Log(buildingHeight);
            levelBuffer.Enqueue(Lvl);
            //3.80f
            //Debug.Log(buildingHeight);
            temp = new Vector3(0, 4.80f, 0);

            if (!loadOnce)
            {
                for (int i = 0; i < 1; i++)
                {
                    LoadNewLevel();
                }
                loadOnce = true;
            } 
        }
    }

    //Get level from our level factory and add it 
    //to the top of the buffer.
    public void LoadNewLevel()
    {

        finishedLevels = levelFactory.GetPooledObject();

        if (finishedLevels != null)
        {
            top = levelBuffer.topOfBuffer();

            finishedLevels.SetActive(true);

            finishedLevels.transform.position = top.GetComponent<Level>().GetTransoform().position;
            
            finishedLevels.transform.position += temp;
            finishedLevels.GetComponent<Level>().setSheetPosition();
            finishedLevels.GetComponent<Level>().getSkelRef().GetComponent<skeleton>().setObsticalPositions();
            levelBuffer.Enqueue(finishedLevels);
            //Debug.Log("active level count is " + levelBuffer.BufferCount());
        }
    }

    public void removeLevel()
    {  
        //Dump the lower level
         rem = levelBuffer.Dequeue();
         

        if (rem.GetComponent<Level>() != null)
        {
            rem.GetComponent<Level>().setObsticalsInactive();
        }
        else
        {
            Debug.Log("level null");
        }

        rem.SetActive(false);
        LoadNewLevel();
    }

    public void increaseLevelState()
    {
        levelFactory.increaseLevelStates();
        
    }

    public void setLevelState(int state)
    {
        levelFactory.setLevelState(state);
    }

}
