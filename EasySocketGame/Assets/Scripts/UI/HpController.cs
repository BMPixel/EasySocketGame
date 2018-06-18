using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour {

	public Image hpImg;
	public float HpPercent
	{
		set{
			hpImg.transform.localScale = new Vector3(value,1,1);
		}
	}
}
