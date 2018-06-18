using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRenderManager : MonoBehaviour {

    
    public Color color;
    public bool randomColor;
    public string tankname;
    [SerializeField]
    private ParticleSystem smoke;
    [SerializeField]
    private SpriteRenderer flag;
    private SpriteRenderer sr;
    private TankPlay tank;


	// Use this for initialization
	void Start () 
    {
        GameObject nameTag = Instantiate(Battlemanager.ins.nameTagPrefab);
        //Debug.Log(tankname);
        //Debug.Log(nameTag);
        nameTag.GetComponent<CameraFollower>().target = transform;
        nameTag.transform.position = transform.position;
        nameTag.transform.Find("Text").GetComponent<Text>().text = tankname;
        tank = GetComponent<TankPlay>();
        tank.tankName = tankname;
        tank.nameTag = nameTag;
		if(randomColor){color = new Color(Random.value, Random.value, Random.value);}
        flag.color = color;
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

}
