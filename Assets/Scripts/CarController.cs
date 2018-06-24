using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    float speedForce = 1f;
    float torqueForce = 50;
    float driftFactor = 2f;
    Transform startTransform;
    float currentPosition = 0;
    float previousPosition = 0;
    private Vector3 myRotation;
    float seeSaw = 0;
    float roatationZ;
    public float currentRotation;
    float curRot;
    float clampedValue;
    private float MinZRot, MaxZRot;
    private float ZRot;

    float rotationZ = 0;

    // Use this for initialization
    void Start () {
        startTransform = this.transform;
        currentPosition = transform.position.x;
        previousPosition = transform.position.x;
        myRotation = this.transform.rotation.eulerAngles;

        MinZRot = -90.0f;
        MaxZRot = 90.0f;
        ZRot = 0;

    }
	
	// Update is called once per frame
	void Update () {


        //ristrict rotation, shake problem, drift stuff too
        rotationZ = this.transform.rotation.z;


        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = ForwardVelocity();

        //if(previousPosition < currentPosition)
        //{
        //    //right
        //    if(Input.acceleration.x < 0)
        //    {
        //        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;
        //    }
        //}
        //else if(previousPosition > currentPosition)
        //{
        //    //left
        //    if (Input.acceleration.x > 0)
        //    {
        //        rb.velocity = ForwardVelocity() + -RightVelocity() * driftFactor;
        //    }
        //}
        //else
        //{

        //}
        //rotationZ = Mathf.Clamp(rotationZ, -60.0f, 60.0f);

        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);

        //this.transform.rotation.eulerAngles.z = Mathf.Clamp(transform.position.z, -10, 10);

        //rotationZ = ClampAngle(rotationZ, -75, 75);

        //transform.eulerAngles = new Vector3(0, 0, rotationZ);



        //transform.localEulerAngles = new Vector3(0,0,ClampAngle(transform.localEulerAngles.x,-80,80));
        //if (rotationZ > 70)
        //{
        //    Debug.Log("here");
        //    Quaternion q = transform.rotation;
        //    q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 70);
        //    transform.rotation = q;
        //}

        //if (myRotation.z < -70)
        //{
        //    Debug.Log("here");
        //    Quaternion q = transform.rotation;
        //    q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, -70);
        //    transform.rotation = q;
        //}
        //Input.acceleration.x

        //if (previousPosition < currentPosition)
        //{

        //}
        GetComponent<Rigidbody2D>().AddForce(transform.up * speedForce);
        //rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

        //if(Input.touchCount > 0 || Input.GetKey(KeyCode.DownArrow))
        //{

        //touch imput
        foreach (Touch touch in Input.touches)
        {

            //accelerate

            //var touch = Input.touches[0];
            //GetComponent<Rigidbody2D>().AddForce(transform.up * speedForce);
            if (touch.position.x < Screen.width / 6)
            {
                //rb.angularVelocity = Input.GetAxis("Horizontal") * torqueForce;
                //rb.AddTorque(torqueForce);
                //rb.angularVelocity = torqueForce;
                rb.AddTorque(torqueForce);
                //myRotation.z = Mathf.Clamp(myRotation.z, -60f, 60f);
            }
            else if(touch.position.x > Screen.width / 6 && touch.position.x < Screen.width / 3)
            {
                rb.AddTorque(torqueForce/4);
            }
            else if((touch.position.x > Screen.width / 3) && (touch.position.x < Screen.width / 1.5))
            {
                //if(rb)
                //transform.rotation = Quaternion.Lerp(this.transform.rotation, startTransform.rotation, Time.deltaTime * 3);
             
                    //right
                    if (this.transform.rotation.z < 0)
                    {
                        
                            
                            rb.AddTorque(torqueForce /2);
                            //seeSaw -= Time.deltaTime;
                            //this.transform.rotation = new Vector3(0, 0, time);
                        

                    }//left
                    else if(this.transform.rotation.z > 0)
                    {
                        
                            rb.AddTorque(-torqueForce/2);
                            //seeSaw += Time.deltaTime;

                        
                    }
                    else
                    {
                       rb.AddTorque(0);
                    }
                
            }
            else if (touch.position.x > Screen.width / 1.5 && touch.position.x < Screen.width / 1.2)
            {
                //rb.angularVelocity = Input.GetAxis("Horizontal") * -torqueForce;
                //rb.AddForce(new Vector2(-10, 0));
                //myRotation.z = Mathf.Clamp(myRotation.z, -60f, 60f);
                rb.AddTorque(-torqueForce / 4);

            }
            else if(touch.position.x > Screen.width / 1.2)
            {
                rb.AddTorque(-torqueForce);
            }
            //}


        }


        //if (Input.acceleration.y < 10)
        //{
        //    //        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;
        //    //    }
        //    rb.AddTorque(torqueForce);
        //}




        previousPosition = currentPosition;
        currentPosition = transform.position.x;







        myRotation.z = Mathf.Clamp(myRotation.z, -60f, 60f);











        if (Input.GetKey(KeyCode.T))
        {
            

        
        }

        if (Input.GetKey(KeyCode.F))
        {
            rb.angularVelocity = torqueForce;
           // myRotation.z = Mathf.Clamp(myRotation.z, -60f, 60f);
            //Debug.Log(seeSaw);
            //curRot = transform.localRotation.eulerAngles.z;
            //clampedValue = Mathf.Clamp(curRot, 2, 60);
            //transform.localRotation = Quaternion.Euler(new Vector3(0, 0, clampedValue));
        }
      
        //right
        if (Input.GetKey(KeyCode.H))
        {
            rb.angularVelocity = -torqueForce;
            //myRotation.z = Mathf.Clamp(myRotation.z, -60f, 60f);
        }
        
        if(!Input.GetKey(KeyCode.H) &&  !Input.GetKey(KeyCode.F))
        {


         





                rb.angularVelocity = 0;

            
           

            //currentRotation = rigidbody.rotation.z;
            //transform.rotation = Quaternion.Slerp(transform.rotation, startTransform.rotation, Time.deltaTime * 20);
            //StartCoroutine(Spin());
        }

        //transform.rotation = Quaternion.Slerp(transform.rotation, startTransform.rotation, Time.deltaTime * 20);
        //accelerometer can increace torque force?
    }


    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);

    }

    //Vector2 LeftVelocity()
    //{
    //    return transform.left * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.lef);

    //}

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);

    }


    public static float ClampAngle(
      float currentValue,
      float minAngle,
      float maxAngle,
      float clampAroundAngle = 0
  )
    {
        float angle = currentValue - (clampAroundAngle + 180);

        while (angle < 0)
        {
            angle += 360;
        }

        angle = Mathf.Repeat(angle, 360);

        return Mathf.Clamp(
            angle - 180,
            minAngle,
            maxAngle
        ) + 360 + clampAroundAngle;
    }



}
