using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadEnemy : Enemy {

    public float DownSpeed;
    public float UpSpeed;

    // Use this for initialization
    void Start () {
        DownSpeed = 0.4f;
        UpSpeed = 0.4f;
    }
	
	// Update is called once per frame
	void Update () {
        switch (behavior)
        {
            case "MoveUp":
                //Debug.Log("pulling from road");
                //return roadState.returnLevel();
                if (this.GetComponent<Renderer>().isVisible)
                {
                    transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    transform.Translate(UpSpeed * Vector3.up * Time.deltaTime, Space.World);
                }
                break;
            case "MoveDown":
                //Debug.Log("pulling from forest");
                //return forestState.returnLevel();
                if (this.GetComponent<Renderer>().isVisible)
                {
                    transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                    transform.Translate(DownSpeed * Vector3.down * Time.deltaTime, Space.World);
                }
                break;
            default:
                //Debug.Log("pulling from null");
                //return null;
                break;
        }
    }

    public override void control(string inBehavior)
    {

    }

    public override void setControl(string inBehavior)
    {
        behavior = inBehavior;
    }

    public override void setSeen(bool inseen)
    {
        seen = inseen;
    }
}
