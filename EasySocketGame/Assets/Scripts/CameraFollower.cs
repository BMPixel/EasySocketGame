using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public Transform target;
    public float speed;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed/Time.deltaTime/50);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
