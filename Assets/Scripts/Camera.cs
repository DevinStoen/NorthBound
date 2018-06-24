using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public float cameraSpeed = 1f;

    public Transform player;
    public GameObject player_go;
    Player playerScript;
    // Use this for initialization
    void Start () {
        player_go = GameObject.FindGameObjectWithTag("Player");
        
        if (player_go == null)
        {
            Debug.Log("could not find player");
            return;
        }
        player = player_go.transform;
        playerScript = player_go.GetComponent<Player>();

    }
	
	// Update is called once per frame
	void Update () {

        // if (playerScript.getTapCount() > 0)
        //{
        //transform.Translate(cameraSpeed * Vector3.up * Time.deltaTime, Space.World);
        //}
        transform.position = new Vector3(0, player.position.y + 1.3f, -4);
    }
}
