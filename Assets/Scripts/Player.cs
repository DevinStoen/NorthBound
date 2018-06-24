using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 100;
    Vector3 position;
    public Rigidbody2D rigidbody;
    int tapCounter;
    float degreesPerSec = 80f;

    float rotAmount = 0;
    float curRot = 0;

    float carVelocity = 0;

    float currentPosition = 0;
    float previousPosition = 0;

    Rigidbody2D myrigidB;

    Quaternion originalRotation;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        position = transform.position;

        currentPosition = transform.position.x;
        previousPosition = transform.position.x;

        myrigidB = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            tapCounter++;
        }

        if (tapCounter % 2 == 1)
        {
            rigidbody.velocity = (Vector3.right * speed * 2 * Time.deltaTime);
        }
        else
        {
            rigidbody.velocity = -(Vector3.right * speed * 2 * Time.deltaTime);
        }



        //replace these arrows with accelerameter input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (previousPosition > currentPosition)
            {
                //do whatever you do when you move left

                DriftLeft();
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (previousPosition < currentPosition)
            {
                //move right stuff


                DriftReft();
            }
        }
        else
        {
            //if (Input.GetKeyUp(KeyCode.RightArrow))
            //{
            returnRotCenter();
            //}
        }
        previousPosition = currentPosition;
        currentPosition = transform.position.x;

    }

    void DriftLeft()
    {
        //float rotAmount = -degreesPerSec * Time.deltaTime * 2;
        //float curRot = transform.localRotation.eulerAngles.z;
        //Debug.Log(curRot);
        
        //curRot += rotAmount;
        //float clampedValue = Mathf.Clamp(curRot, 0, 0);
        //transform.localRotation = Quaternion.Euler(new Vector3(0, 0, clampedValue));
        
    }

    void DriftReft()
    {
        float rotAmount = degreesPerSec * Time.deltaTime * 2;
        float curRot = transform.localRotation.eulerAngles.z;
        Debug.Log(curRot);
        curRot += rotAmount;
        float clampedValue = Mathf.Clamp(curRot, 0, 35);
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, clampedValue));

    }

    void returnRotCenter()
    {
        //transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * 20);
    }
}
