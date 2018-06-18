using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNormal : MonoBehaviour 
{

    public static List<BulletNormal> BulletPool = new List<BulletNormal>(100);

    public static BulletNormal GetABullet(Vector2 position, Vector2 velocity, int team, float damage)
    {
        foreach(BulletNormal blt in BulletPool)
        {
            if(!blt.actived)
            {
                blt.Active();
                blt.transform.position = position;
                blt.velocity = velocity;
                blt.team = team;
                return blt;
            }
        }
        
        BulletNormal nb = Instantiate(Battlemanager.ins.bulletSmall).GetComponent<BulletNormal>();
        BulletPool.Add(nb);
        nb.transform.position = position;
        nb.velocity = velocity;
        
        return nb;
    }

    public bool actived { get;set; }

    public Vector3 velocity { get; set; }

    public int team { get; set; }

    public void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

	public void Start () 
    {
        actived = true;
        transform.right = velocity.normalized;
        transform.position += transform.right * 2;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        TankPlay tp = coll.gameObject.GetComponent<TankPlay>();
        if(tp != null)
        {
            if( tp.team != team)
            {
                //Debug.Log(string.Format("{0}/{1} Hitted eme!!",tp.team,team));
                tp.HP -= 5;
            }else
                return;
        }
        //Debug.Log("Hitted!!");
        
        Disable();
    }
	
    public void Disable()
    {
        actived = false;
        gameObject.SetActive(false);
    }

    public void Active()
    {
        actived = true;
        gameObject.SetActive(true);
    }
}
