using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSkyMove : MonoBehaviour {

    public float ratio;
    public Transform target;
    public Transform background;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        background.localPosition = (target.position - background.position) / ratio;
        background.localPosition += Vector3.forward * 10;
	}
}
