using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//TODO
//random map block
//tankmove
//
//
//
//

public class Battlemanager: MonoBehaviour
{
    public int maxTankCount = 15;
    public bool IsPause = false;
    public Dictionary<int,GameObject> starList = new Dictionary<int,GameObject>();
    public List<TankPlay> rankList = new List<TankPlay>();
    public int playerId;
    public System.Random rand = new System.Random();
    public int id = 0;
    static public Battlemanager ins;
    public GameObject playerPrefab;
    public GameObject AiPrefab;
    public Canvas DiedUI;
    public GameObject nameTagPrefab;
    public Text rankText;
    public GameObject bulletSmall;
    

    public void Start()
    {
        ins = this;
        DiedUI.enabled = false;
        PlacePlayer(new Vector2(20, 20));
    }

    public void Update()
    {
        if(Time.frameCount%120 == 0)
        {
            //Rank();
        }
        if (starList.Count < maxTankCount)
        {
            PlaceAi();
        }
    }

   /* public void Rank()
    {
        if (rankList.Count < 3)
            return;
        rankList.Sort();
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=#4081FF>1.{0}:\t\t{1:f1}</color>\n<color=#84AEFF>2.{2}:\t\t{3:f1}</color>\n<color=#BDD4FF>3.{4}:\t\t{5:f1}</color>\n",
            rankList[0].starName, rankList[0],
            rankList[1].starName, rankList[1],
            rankList[2].starName, rankList[2]
            );
        int max = 9;
        if (rankList.Count < 9)
            max = rankList.Count;
        for (int i = 3; i < max; i++)
        {
            sb.AppendFormat("{0}.{1}:\t\t{2:f1}\n", i + 1, rankList[i].starName, rankList[i].mass);
        }
        for (int i = 0; i < rankList.Count; i++)
        {
            if (rankList[i].id == Battlemanager.ins.playerId)
            {
                sb.AppendFormat("<color=#BDD4FF>{0}.{1}:\t\t{2:f1}</color>", i + 1, rankList[i].starName, rankList[i].mass);
            }
        }
        rankText.text = sb.ToString();
    }*/

    public GameObject FindClosetStar(GameObject go)
    {
        Vector3 pos = go.transform.position;
        GameObject ret = null;
        float ds = 0;
        if (starList.Count == 0)
        {
            return null;
        }
        foreach (KeyValuePair<int, GameObject> player in starList)
        {
            if (ret == null)
            {
                ret = player.Value;
                ds = Vector3.Distance(ret.transform.position, pos);
            }
            float nds = Vector3.Distance(player.Value.transform.position, pos);
            if (nds < ds && player.Value != go)
            {
                ds = nds;
                ret = player.Value;
            }
        }
        return ret;
    }

    public void PlacePlayer()
    {
        PlacePlayer(SetBattleGround.ins.randomPos);
    }

    public int GetId()
    {
        return id++;
    }

    public void PlacePlayer(Vector2 pos)
    {
        GameObject player = GameObject.Instantiate<GameObject>(ins.playerPrefab,pos,Quaternion.identity);
        int id = GetId();
        player.GetComponent<TankPlay>().id = id;
        player.GetComponent<TankPlay>().team = id;
        Camera.main.GetComponent<CameraFollower>().target = player.transform;
        Camera.main.GetComponent<CameraFollower>().enabled = true; //set new Camera target
        DiedUI.enabled = false;
        playerId = id; // global player id
        starList.Add(id, player); // To dict
        rankList.Add(player.GetComponent<TankPlay>());
    }

    public void PlaceAi()
    {
        PlaceAi(SetBattleGround.ins.randomPos);
    }

    public void PlaceAi(Vector2 pos)
    {
        GameObject ai = GameObject.Instantiate<GameObject>(Battlemanager.ins.AiPrefab, pos, Quaternion.identity);
        int id = GetId();
        ai.GetComponent<PlayerRenderManager>().tankname = "AI-" + id;
        ai.GetComponent<TankPlay>().id = id;
        ai.GetComponent<TankPlay>().team = id;
        Battlemanager.ins.starList.Add(id, ai);
        rankList.Add(ai.GetComponent<TankPlay>());
    }
}
