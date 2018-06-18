using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesTankNormal : SpeciesTank 
{
	public float speed = 10;
	private TankPlay tank;
	public float damage = 10;
    public override void Fight()
    {
        //Debug.Log(string.Format("{0}:currentTeam-->{1}",tank.name,tank.team));
		if(tank.direction != Vector2.zero)
        	BulletNormal.GetABullet(transform.position, tank.direction.normalized * speed,tank.team,damage);
    }

    public override void SetTexture()
    {
        throw new System.NotImplementedException();
    }

    protected override void Start()
    {
        tank = GetComponent<TankPlay>();
		if(tank == null)
			throw new System.Exception("TankPlay Script was not implement!!");
    }

    protected override void Update()
    {
    }
}
