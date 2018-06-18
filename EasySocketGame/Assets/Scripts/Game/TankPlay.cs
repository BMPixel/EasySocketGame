using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankPlay : MonoBehaviour, IComparable<TankPlay>
{
    public int hpTotal = 100;
    private int hp = 100;
    public int HP
    {
        get{return hp;}
        set{
            nameTag.GetComponent<HpController>().HpPercent = (float)value/(float)hpTotal;
            hp = value;
        }
    }
    public float speed = 3;
    public GameObject nameTag;
    public Vector2 direction;
    public int id;
    public string tankName;
    public int team;
    private Vector2 tempVelocity = Vector2.zero;
    private Vector2 tempPosition = Vector2.zero;
    private Rigidbody2D rb;
    public Vector3 velocity
    {
        get{return rb.velocity;}
        set{rb.velocity = value;}
    }
    public int fireTime;


    // Use this for initialization
    virtual public void Start()
    {
        hp = hpTotal;
        rb = GetComponent<Rigidbody2D>();
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
    }

    virtual public void FixedUpdate()
    {
        rb.velocity = direction * speed;
        if(fireTime > 0 || hp <= 0)
        {
            fireTime --;
            rb.velocity = Vector3.zero;
        }
        transform.right = direction;
    }

    virtual public void Die()
    {
        Destroy(gameObject);
        Destroy(nameTag);
        Battlemanager.ins.starList.Remove(id);
        Battlemanager.ins.rankList.Remove(this);
    }

    public int Compare(TankPlay x, TankPlay y)
    {
        if (x.rb.mass > y.rb.mass) return 1;
        else if (x.rb.mass == y.rb.mass) return 0;
        else return -1;
    }

    public int CompareTo(TankPlay other)
    {
        if(other == null || other.rb == null)
            return 1;
        if (rb.mass > other.rb.mass) return -1;
        if (rb.mass == other.rb.mass) return 0;
        return 1;
    }

    public bool Fight()
    {
        if(fireTime > 0)
            return false;
        fireTime = 12;
        return true;
    }
}
