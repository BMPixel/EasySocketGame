using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpeciesTank : MonoBehaviour 
{
	public abstract void Fight();
	protected abstract void Start();
	protected abstract void Update();
	public abstract void SetTexture();
}