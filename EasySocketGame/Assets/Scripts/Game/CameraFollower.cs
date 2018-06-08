using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public Transform target;
    public float speed;
    public float z_offset;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(speed == -1)
        {
            transform.position = target.position;
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed/Time.deltaTime/50);
        transform.position = new Vector3(transform.position.x, transform.position.y, z_offset);
	}
}
