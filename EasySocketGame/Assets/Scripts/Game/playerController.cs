using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : StarPlay 
{

	// Use this for initialization
    override public void Start() 
    {
        base.Start();
	}

    override public void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
        base.Update();
    }


    override public void FixedUpdate() 
    {
        base.FixedUpdate();
        //Delete
        if(Input.GetKeyDown(KeyCode.M))
        {
            rb.velocity *= -1;
        }
        //
	}

    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    override public void Die()
    {
        Camera.main.GetComponent<CameraFollower>().enabled = false;
        Battlemanager.ins.DiedUI.enabled = true;
        base.Die();
    }

    
}
