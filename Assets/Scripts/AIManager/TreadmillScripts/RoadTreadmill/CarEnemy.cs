using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemy : MonoBehaviour {


    public string behavior = "";
    public float Speed;
    public Vector3 startRotation;
    Renderer carRenderer;
    public bool seen;
    public RoadSpawn mySpawnRef;
    // Use this for initialization
    void Start () {
        //transform.localRotation = Quaternion.Euler(new Vector3(0, 0, startRotation));
        carRenderer = this.GetComponentInChildren<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {



        if (carRenderer.isVisible)
        {
            seen = true;
           
        }
        if (seen && !carRenderer.isVisible)
        {
            //deactivate itself
            
            if(mySpawnRef != null)
            {
                Debug.Log("Here");
                mySpawnRef.obsticalDeactivated();
                mySpawnRef.setLaneActiveBool(false);
            }
            seen = false;
            this.gameObject.SetActive(false);
        }


        if (behavior == "Down")
        {
            transform.Translate(Speed * Vector3.down * Time.deltaTime, Space.World);
        }
        else if(behavior == "Up")
        {
            transform.Translate(Speed * Vector3.up * Time.deltaTime, Space.World);
        }
        else if(behavior == "changeLanesDownLtR")
        {
            
        }
        else if (behavior == "changeLanesDownRtL")
        {

        }

        transform.localRotation = Quaternion.Euler(startRotation);
    }

    public void setBehavior(string behave)
    {
        behavior = behave;
    }

    public void setSpeed(float inSpeed)
    {
        Speed = inSpeed;
    }

    public void setRotation(Vector3 inRot)
    {
        startRotation = inRot;
    }

    public void setSpawnRef(RoadSpawn inSpawn)
    {
        mySpawnRef = inSpawn;
    }

 
}
