using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : TankPlay 
{

	// Use this for initialization
    override public void Start() 
    {
        base.Start();
	}

    override public void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;
        direction.Normalize();
        if(Input.GetMouseButton(0) && Fight())
        {
            SendMessage("Fight");
        }
        base.Update();
    }


    override public void FixedUpdate() 
    {
        base.FixedUpdate();
	}

    override public void Die()
    {
        Camera.main.GetComponent<CameraFollower>().enabled = false;
        Battlemanager.ins.DiedUI.enabled = true;
        base.Die();
    }

    
}
