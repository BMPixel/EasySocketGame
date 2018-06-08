using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCountBorad : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start () 
    {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(Time.frameCount%100 == 0)
        {
            text.text = string.Format("当前人数：{0}\n", Battlemanager.ins.starList.Count);
        }
	}
}
