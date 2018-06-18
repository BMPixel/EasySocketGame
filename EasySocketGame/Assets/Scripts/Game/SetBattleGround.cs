using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBattleGround : MonoBehaviour {

    public Transform terrianGround;
    public Transform bounceWall;
    public GameObject blanket;
    public int left = 0;
    public int top = 0;
    public int right = 100;
    public int bottom = 100;
    public Vector2 randomPos
    {
        get
        {
            return new Vector2(Random.Range(left, right-1), Random.Range(top, bottom-1));
        }
    }
    public int width { get{return right - left; }}
    public int height { get { return bottom - top; } }
    public static SetBattleGround ins;


	// Use this for initialization
	void Start () 
    {
        ins = this;
        bounceWall.localScale = new Vector2(right - left, bottom - top);
        bounceWall.position = new Vector3(left-0.5f, top-0.5f);
		for(int i = left; i < right; i++)
        {
            for(int j = top; j < bottom; j++)
            {
                Instantiate(blanket, terrianGround).transform.position = new Vector3(i,j,0);
            }
        }
	}
}
