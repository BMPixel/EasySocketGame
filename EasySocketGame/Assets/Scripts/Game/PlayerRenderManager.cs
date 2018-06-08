using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRenderManager : MonoBehaviour {

    public ParticleSystem par1;
    public ParticleSystem par2;
    public SpriteRenderer sr;
    public TrailRenderer trail;
    public Color color;
    public bool randomColor;
    private StarPlay star;
    public float initScale = 1.35f;
    public string name;

	// Use this for initialization
	void Start () 
    {
        GameObject nameTag = Instantiate(Battlemanager.ins.nameTagPrefab);
        nameTag.GetComponent<CameraFollower>().target = transform;
        nameTag.transform.position = transform.position;
        nameTag.transform.Find("Text").GetComponent<Text>().text = name;
        star = GetComponent<StarPlay>();
        star.starName = name;
        star.nameTag = nameTag;
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
        trail.startWidth = initScale;
        transform.localScale = new Vector3(initScale, initScale);
	}

    public void ChangeScale(float ratios)
    {
        ratios = Mathf.Sqrt(ratios);
        trail.startWidth = initScale * ratios;
        transform.localScale = Vector3.one * ratios * initScale;
        star.nameTag.transform.Find("Text").localPosition = Vector2.up * transform.localScale.y;
    }
	
	// Update is called once per frame
	void Update () 
    {
        ParticleSystem.EmissionModule em =  par1.emission;
        em.rateOverTime = star.currentSpeed * 20;
        em = par2.emission;
        em.rateOverTime = star.currentSpeed * 20;
	}
}
