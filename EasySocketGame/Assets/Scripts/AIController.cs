using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : StarPlay
{

    // Use this for initialization
    void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (Time.frameCount % 10 == 0)
            AI();
        base.Update();
    }

    void AI()
    {
        direction = (Battlemanager.FindClosetStar(gameObject).transform.position - transform.position).normalized;

    }


    void FixedUpdate()
    {
        base.FixedUpdate();

    }


}
