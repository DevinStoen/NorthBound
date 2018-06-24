using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour {

    public int startRotation;
    public string direction;
    bool Active = false;
    public float Speed;
    RoadTreadmill treadmillRef;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setLaneActiveBool(bool inSet)
    {
        Active = inSet;
    }


    public bool getLaneActive()
    {
        return Active;
    }


    public Vector3 getSpawnRotation()
    {
        return new Vector3(0, 0, startRotation);
    }

    public string getDirection()
    {
        return direction;
    }

    public Transform getPosition()
    {
        return this.transform;
    }

   public float getSpeed()
    {
        return Speed;
    }

    public void setTreadmillRef(RoadTreadmill treadmill)
    {
        treadmillRef = treadmill;
    }

    public void obsticalDeactivated()
    {
        treadmillRef.enemyDeactivate();
    }


}
