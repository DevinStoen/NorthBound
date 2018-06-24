using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTreadmill : ObsticalTreadmill {

    public List<Transform> topSpawns;
    public List<Transform> treadSpawn;



    int randomEnemy;
    int chooseSpawn;

    public Transform bottonBoundary;
    public Transform topBoundary;

    //float time = 0.0f;
    public int activeCars = 0;

    public int roadState = 0;
    bool startOnce;

    //total plays so far
    int totalLevelPlays = 2;
    int levelTime = 0;


    void Awake()
    {
        treadmillObsticals = new List<GameObject>();
        treadSpawn = new List<Transform>();
        topSpawns = new List<Transform>();
    }
    // Use this for initialization
    
	// Use this for initialization
	void Start () {

        foreach (Transform child in transform)
        {
            //child is your child transform
            treadSpawn.Add(child);
            child.GetComponent<RoadSpawn>().setTreadmillRef(this);
            if(child.tag == "TopSpawn")
            {
                topSpawns.Add(child);
            }
        }
        // topSpawn = new List<GameObject>();
        StartCoroutine(CarTiming());
    }
	
	// Update is called once per frame
	void Update () {
        // Debug.Log(treadmillObsticals.Count);
        RoadEnemyControl();

    }

    public override void addLevel(GameObject inObj)
    {
        
        treadmillObsticals.Add(inObj);
        
    }

    //here for now
    void RoadEnemyControl()
    {

        //two cars at once?
        //set car combinations?
        //restrict the amount of cars at a time
        //cars should be seperate lanes???


        //raod stages
        //random car spawns
        //cars start having planned plays
        //boss battle


        //implememt timer to control roadstate, 
        //total time is sent from gamemanger and the treadmil
        //script splits up the time from there.

        if(roadState == 0)
        {
            if (!startOnce)
            {
                
               // startOnce = true;
                //OneLaneOnlyPlay(2);
                //randomCarSpawnPhase();
            }
        }
        else if(roadState == 1)
        {

            startOnce = false;

        }
        else if(roadState == 2)
        {
            startOnce = false;
        }

    }

    IEnumerator CarTiming()
    {
        while (true)
        { 
                if(roadState == 0)
                {
                    if (activeCars < 3)
                    {
                        randomCarSpawnPlay();
                    }
                }
                else if(roadState == 1)
                {
                //if (!startOnce)
                //{

                    if (activeCars == 0)
                    {
                        int lane = Random.Range(0, 3);
                        //Debug.Log("lane closed: " + lane);
                        OneLaneOnlyPlay(lane);
                        //startOnce = true;
                    }
                    //}
                }
            
            yield return new WaitForSeconds(1f);
        }
    }

    public void spawnObstical(GameObject spawnEnemy, Transform spawnPoint)
    {
        //Transform spawnPoint = inSpawn;
        //spawnEnemy = treadmillObsticals[randomEnemy];
        //spawnPoint = treadSpawn[chooseSpawn];
        spawnEnemy.SetActive(true);
        spawnPoint.GetComponent<RoadSpawn>().setLaneActiveBool(true);
        activeCars++;
        spawnEnemy.GetComponent<CarEnemy>().setSpawnRef(spawnPoint.GetComponent<RoadSpawn>());
        spawnPoint.transform.localRotation = Quaternion.Euler(spawnPoint.GetComponent<RoadSpawn>().getSpawnRotation());
        spawnEnemy.GetComponent<CarEnemy>().setBehavior(spawnPoint.GetComponent<RoadSpawn>().getDirection());

        spawnEnemy.GetComponent<CarEnemy>().setRotation(spawnPoint.GetComponent<RoadSpawn>().getSpawnRotation());
        //spawnEnemy.GetComponent<CarEnemy>().setRotation(spawnPoint.GetComponent<RoadSpawn>().getSpawnRotation());

        spawnEnemy.transform.position = spawnPoint.GetComponent<RoadSpawn>().getPosition().position;
        spawnEnemy.GetComponent<CarEnemy>().setSpeed(spawnPoint.GetComponent<RoadSpawn>().getSpeed());
    }


    public void randomCarSpawnPlay()
    {
        randomEnemy = Random.Range(0, treadmillObsticals.Count);

        chooseSpawn = Random.Range(0, treadSpawn.Count);

        GameObject spawnEnemy;
        Transform spawnPoint;


        while (treadSpawn[chooseSpawn].GetComponent<RoadSpawn>().getLaneActive())
        {
            chooseSpawn = UnityEngine.Random.Range(1, treadSpawn.Count);
        }

        while (treadmillObsticals[randomEnemy].activeInHierarchy)
        {
            randomEnemy = UnityEngine.Random.Range(1, treadmillObsticals.Count);
        }

        spawnEnemy = treadmillObsticals[randomEnemy];
        spawnPoint = treadSpawn[chooseSpawn];

        spawnObstical(spawnEnemy, spawnPoint);

    }

    public void OneLaneOnlyPlay(int laneOpen)
    {
        GameObject spawnEnemy;
        Transform spawnPoint;
        for (int i = 0; i < topSpawns.Count; i++)
        {
            if(i != laneOpen)
            {

                randomEnemy = Random.Range(0, treadmillObsticals.Count);
                while (treadmillObsticals[randomEnemy].activeInHierarchy)
                {
                    randomEnemy = UnityEngine.Random.Range(1, treadmillObsticals.Count);
                }

                spawnEnemy = treadmillObsticals[randomEnemy];
                spawnPoint = topSpawns[i];
                //Transform spawn = ;
                spawnObstical(spawnEnemy, spawnPoint);
            }
        }
    }

    public void setRoadState(int state)
    {
        roadState = state;
        
    }

    public void enemyDeactivate()
    {
        activeCars = activeCars - 1;
    }

    public override void setTotalTimeForLevel(int inTime)
    {
        //levelTime = inTime;
    }



}
