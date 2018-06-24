using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFactory : MonoBehaviour {

    public List<IState> states;
    GameObject obj;
    public int pooledAmount = 3;

    public GameObject[] levelBackgrounds;

    public int stateAmounts = 2;
    int curstate = 0;

    //two levels for now.
    public IState roadState;
    public IState forestState;


    void Start()
    {
        //REMEMEBR
        //add states to state list
        states = new List<IState>();
        states.Add(roadState);
        states.Add(forestState);

        for (int i = 0; i < pooledAmount; i++)
        {
            //may not need this, drag and drop ??
            if(i < 4)
            {
                //load road levels
                obj = (GameObject)Instantiate(levelBackgrounds[i]);
                obj.SetActive(false);
                roadState.addLevel(obj);
            }
            if(i > 3 && i < 15)
            {
                //load forest levels
                obj = (GameObject) Instantiate(levelBackgrounds[i]);
                obj.SetActive(false);
                forestState.addLevel(obj);
            }
            
            //levels are ready  
        }
    }
   
    //Result of level factory.
    public GameObject GetPooledObject()
    {
        //based on the terrain state of the game,
        //pull a background image, choose a level skeleton
        //and choose correct level obsticals.
        curstate = curstate % stateAmounts;
        //temarary level generation
        switch (curstate)
        {
            case 0:
                Debug.Log("pulling from road");
                return roadState.returnLevel();
            case 1:
                Debug.Log("pulling from forest");
                return forestState.returnLevel();
            default:
                Debug.Log("pulling from null");
                return null;
        }
    }


    public void increaseLevelStates()
    {
        //changes the levels being spawned from "forest" to "snow" for example
        states[curstate].endState();
        curstate++;
       
    }

    public void setLevelState(int inState)
    {
        curstate = inState;
    }

}
