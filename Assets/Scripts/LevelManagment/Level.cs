using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is the base Level class. soon to be abstract
public class Level : MonoBehaviour {


    
    //public bool off;
    public bool seen;
    Renderer levelRenderer;
    LevelManager levelManagerRef;
    public GameObject mySkel;
    //bool imActive;
    public int obsticalCount;

    

    // Use this for initialization
    void Start () {
        levelRenderer = this.GetComponentInChildren<Renderer>();
        levelManagerRef = GameObject.Find("LevelManager").GetComponent<LevelManager>();

    }
	
	// Update is called once per frame
	void Update () {

        if (levelRenderer.isVisible)
        {
            seen = true;
            if (mySkel != null)
            {
                mySkel.GetComponent<skeleton>().setSeen(true);
            }
        }

        if (seen && !levelRenderer.isVisible)
        {
            if (mySkel != null)
            {
                mySkel.GetComponent<skeleton>().setSeen(false);
            }
            if (levelManagerRef != null)
            {    
                levelManagerRef.removeLevel();
            }
            seen = false;
        }

    }

    public Transform GetTransoform()
    {
        return this.transform;
    }

    public void setLevelObsticals()
    {

    }
    
    public void setObsticalSheet(GameObject inSkel)
    {
        mySkel = inSkel;
        
    }

    public void setSheetPosition()
    {
        mySkel.GetComponent<skeleton>().setSkelPosition(this.transform);

    }

    public GameObject getSkelRef()
    {
        return mySkel;
    }

    public void setObsticalsInactive()
    {
        if (mySkel != null)
        {
            mySkel.GetComponent<skeleton>().setObsticalsInactive();
            mySkel.SetActive(false);
            mySkel = null;
        }
    }

}
