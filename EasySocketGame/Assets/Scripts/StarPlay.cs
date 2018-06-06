using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPlay : MonoBehaviour
{

    public float speed = 3;
    public float acceleration = 3;
    protected Rigidbody2D rb;
    public float currentSpeed;
    public Vector2 direction;

    // Use this for initialization
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Battlemanager.AiList.Add(gameObject);
    }

    public void Update()
    {
        transform.Rotate(Vector3.forward, currentSpeed);
    }


    public void FixedUpdate()
    {
        rb.AddForce(direction * acceleration);
        currentSpeed = rb.velocity.magnitude;
        if (currentSpeed > speed / Time.fixedDeltaTime)
            rb.velocity = rb.velocity / currentSpeed * speed / Time.fixedDeltaTime;

    }


}
