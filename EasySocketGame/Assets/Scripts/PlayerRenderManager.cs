using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderManager : MonoBehaviour {

    public ParticleSystem par1;
    public ParticleSystem par2;
    public SpriteRenderer sr;
    public TrailRenderer trail;
    public Color color;
    public bool randomColor;

	// Use this for initialization
	void Start () 
    {
		if(randomColor)
        {
            color = new Color(Random.value, Random.value, Random.value);
        }

        sr.color = color;
        ParticleSystem.MainModule m = par1.main;
        m.startColor = color;
        m = par2.main;
        m.startColor = color;
        trail.endColor = color;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
