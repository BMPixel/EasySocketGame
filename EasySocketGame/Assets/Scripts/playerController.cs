using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : StarPlay 
{

	// Use this for initialization
	void Start () 
    {
        base.Start();
	}
	
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
        base.Update();
    }


	void FixedUpdate () 
    {
        base.FixedUpdate();
        //Delete
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
        }
        //
	}

    
}
