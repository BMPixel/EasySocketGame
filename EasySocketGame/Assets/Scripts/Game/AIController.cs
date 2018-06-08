using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : StarPlay
{

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
        Vector2 v = obj.GetComponent<Rigidbody2D>().velocity;
        direction = (obj.position - transform.position).normalized;
        if(v.sqrMagnitude > currentSpeed*currentSpeed && Vector2.Distance(obj.position,transform.position) < 5)
        {
            direction *= -1;
            if(Vector2.Angle(v,rb.velocity) > 90)
            {
                rb.velocity *= -1;
            }
        }

    }


    override public void FixedUpdate()
    {
        base.FixedUpdate();

    }

    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    override public void Die()
    {
        base.Die();
    }


}
