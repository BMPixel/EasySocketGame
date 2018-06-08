using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StarPlay : MonoBehaviour, IComparable<StarPlay>
{
    public float speed = 3;
    public float acceleration = 3;
    protected Rigidbody2D rb;
    public float mass
    {
        get { return rb.mass; }
    }
    public float currentSpeed;
    public Vector2 direction;
    private float initMass = 0.8f;
    public GameObject nameTag;
    public int id;
    private Vector2 tempVelocity = Vector2.zero;
    private Vector2 tempPosition = Vector2.zero;
    public string starName;

    // Use this for initialization
    virtual public void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        initMass = rb.mass;
    }

    virtual public void Update()
    {
        if (Battlemanager.ins.IsPause && tempVelocity == Vector2.zero)
        {
            tempPosition = transform.position;
            tempVelocity = rb.velocity;
            rb.velocity = Vector2.zero;
            return;
        }
        else if (Battlemanager.ins.IsPause && tempVelocity != Vector2.zero)
        {
            transform.position = tempPosition;
            return;
        }
        else if (!Battlemanager.ins.IsPause && tempVelocity != Vector2.zero)
        {
            rb.velocity = tempVelocity;
            tempVelocity = Vector2.zero;
        }
        transform.Rotate(Vector3.forward, currentSpeed);
    }


    virtual public void FixedUpdate()
    {
        rb.AddForce(direction * acceleration);
        currentSpeed = rb.velocity.magnitude;
        if (currentSpeed > speed / Time.fixedDeltaTime)
            rb.velocity = rb.velocity / currentSpeed * speed / Time.fixedDeltaTime;

    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<StarPlay>()!=null)
        {
            float offset = 1;
            Vector2 cv = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            if (cv.sqrMagnitude > rb.velocity.sqrMagnitude)
                offset *= -1;
            offset *= ((cv - rb.velocity).magnitude/40);
                
            rb.mass += offset;
            if(rb.mass <= 0.1)
            {
                Die();
            }
            GetComponent<PlayerRenderManager>().ChangeScale(rb.mass / initMass);
            //Battlemanager.ins.Rank();
        }
    }

    virtual public void Die()
    {
        Destroy(gameObject);
        Destroy(nameTag);
        Battlemanager.ins.starList.Remove(id);
        Battlemanager.ins.rankList.Remove(this);
    }



    public int Compare(StarPlay x, StarPlay y)
    {
        if (x.rb.mass > y.rb.mass) return 1;
        else if (x.rb.mass == y.rb.mass) return 0;
        else return -1;
    }

    public int CompareTo(StarPlay other)
    {
        if(other == null || other.rb == null)
            return 1;
        if (rb.mass > other.rb.mass) return -1;
        if (rb.mass == other.rb.mass) return 0;
        return 1;
    }
}
