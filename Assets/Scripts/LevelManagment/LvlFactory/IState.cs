using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IState : MonoBehaviour {


    
    public List<GameObject> levelList;

    public GameObject[] obsticals;
    public List<GameObject> obsList;

    
    public abstract void endState();
    public int pullCount;
    public int skelAmount;
    public abstract void addLevel(GameObject inLvl);
    //public abstract GameObject returnLevel();

    public int randomPoolInt;
    public int randomSkelInt;
    public int randomObsInt;

    public abstract GameObject returnLevel();
    public GameObject levelObsticals;
    public GameObject buildLevel;

    public IObsticalFactory myFactory;

    public GameObject levelObsticalSheet;
    public GameObject obj;

    public void setLevelInactive()
    {
        //buildLevel.SetActive(false);
        //levelObsticalSheet.SetActive(false);

    }

}
