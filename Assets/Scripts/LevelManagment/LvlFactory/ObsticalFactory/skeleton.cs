using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour {

    List<Transform> spawnList;
    public List<GameObject> obsticals;
    
    private void Awake()
    {
        spawnList = new List<Transform>();
        obsticals = new List<GameObject>();
        //foreach (GameObject child in transform)
        //{
        //    //child is your child transform
        //    spawnList.Add(child);
        //}
        foreach (Transform child in transform)
        {
            //child is your child transform
            spawnList.Add(child);
        }
    }
    // Use this for initialization
    void Start () {
        
    }
	

    public void setSkeletonObsticals()
    {

    }

    public int getSpawnPointCount()
    {
        return spawnList.Count;
    }

    public void setSkelPosition(Transform intrans)
    {
        this.transform.position = intrans.position;
    }


    public Transform getSpawnPos(int pos)
    {
        return spawnList[pos];
    }

    public void setObstical(GameObject inObs)
    {
        if(obsticals == null)
        {
            obsticals = new List<GameObject>();
        }
        obsticals.Add(inObs);
    }

    public void setObsticalPositions()
    {
        
            for (int i = 0; i < spawnList.Count; i++)
            {
                obsticals[i].transform.position = spawnList[i].transform.position;
                obsticals[i].GetComponent<Enemy>().setControl(spawnList[i].tag);
            }
        
    }

    public void setObsticalsInactive()
    {
            
            for (int i = 0; i < spawnList.Count; i++)
            {
                obsticals[i].SetActive(false);
                //obsticals = null;
            }
        obsticals = null;

    }

    public void setSeen(bool inSeen)
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            obsticals[i].GetComponent<Enemy>().setSeen(inSeen);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
