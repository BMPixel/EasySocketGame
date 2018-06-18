using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : TankPlay
{

    List<TankPlay> tanks = new List<TankPlay>();
    // Use this for initialization
    override public void Start()
    {
        base.Start();
    }

    override public void Update()
    {
        if (Time.frameCount % 10 == 0)
            AI();
        base.Update();
    }

    void AI()
    {
        Transform obj = Battlemanager.ins.FindClosetStar(gameObject).transform;
        direction = (obj.position - transform.position);
        if(direction.sqrMagnitude < 60 && Fight()) // close enough
        {
            if(HP < 0.4 * hpTotal) // run away
            {
                Debug.Log(tanks.Count);
            }
            SendMessage("Fight");
        }
        direction.Normalize();
    }


    override public void FixedUpdate()
    {

        base.FixedUpdate();
    }

    override public void Die()
    {
        base.Die();
    }


}
