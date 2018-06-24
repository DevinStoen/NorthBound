using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {


    List<GameObject> aiTreadmills;
    public GameObject[] treadmills;
    //public GameObject[] treadObsticals;
    public GameObject[] roadObsticals;
    public GameObject[] forestObsticals;

    GameObject obj;
    GameObject addobj;
    public Transform player;
    int treadState = 0;
    // Use this for initialization
    void Start () {

        aiTreadmills = new List<GameObject>();

        for (int i = 0; i < treadmills.Length; i++)
        {
            
            //load road levels
            obj = (GameObject)Instantiate(treadmills[i]);
            obj.SetActive(false);
            aiTreadmills.Add(obj);
            
            //levels are ready  
        }

        //load the objects to the cooresponding treadmill
        for(int i = 0; i < aiTreadmills.Count; i++)
        {

            if (i == 0)
            {
                for (int j = 0; j < roadObsticals.Length; j++)
                {

                    addobj = (GameObject)Instantiate(roadObsticals[j]);
                    addobj.SetActive(false);
                    aiTreadmills[i].GetComponent<ObsticalTreadmill>().addLevel(addobj);

                }
            }

            if(i == 1)
            {
                for (int j = 0; j < forestObsticals.Length; j++)
                {
                    addobj = (GameObject)Instantiate(forestObsticals[j]);
                    addobj.SetActive(false);
                    aiTreadmills[i].GetComponent<ObsticalTreadmill>().addLevel(addobj);

                }
            }
            

        }


        setUpTreadmill();


    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(aiTreadmills.Count);
        aiTreadmills[treadState].transform.position = new Vector3(0, player.position.y + 1.3f, -1);


        //switch (treadState)
        //{
        //    case 0:
        //        Debug.Log("pulling from road");
        //        //return null;
        //    case 1:
        //        Debug.Log("pulling from forest");
        //       // return null;
        //    default:
        //        Debug.Log("pulling from null");
        //        //return null;
        //}


    }


    public void setLevelState(int state)
    {
        aiTreadmills[treadState].SetActive(false);
        treadState = state;
        setUpTreadmill();

    }

    public void setUpTreadmill()
    {
        aiTreadmills[treadState].SetActive(true);
        aiTreadmills[treadState].transform.position = player.transform.position;
    }


    //public void setTotalLevelTime(int currentLevelTime)
    //{
    //    aiTreadmills[treadState].setTotalTimeForLevel(currentLevelTime);

    //}


}
