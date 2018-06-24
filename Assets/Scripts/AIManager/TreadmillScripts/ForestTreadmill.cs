using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTreadmill : ObsticalTreadmill
{

    void Awake()
    {
        treadmillObsticals = new List<GameObject>();
    }


    // Use this for initialization
    void Start()
    {
        //treadmillObsticals = new List<GameObject>();

    }

    // Update is called once per frame
    void Update(){
        
    }

    public override void addLevel(GameObject inObj)
    {
        treadmillObsticals.Add(inObj);
    }

    public override void setTotalTimeForLevel(int inTime)
    {
        throw new NotImplementedException();
    }


}
