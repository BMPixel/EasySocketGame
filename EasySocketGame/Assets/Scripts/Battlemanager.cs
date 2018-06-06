using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Battlemanager{

    static public List<GameObject> playerList = new List<GameObject>();
    static public List<GameObject> AiList = new List<GameObject>();

    static public GameObject FindClosetPlayer(Vector2 pos)
    {
        if(playerList.Count == 0)
        {
            return null;
        }
        GameObject ret = playerList[0];
        float ds = Vector3.Distance(ret.transform.position,pos);
        foreach(GameObject player in playerList)
        {
            float nds = Vector3.Distance(player.transform.position,pos);
            if(nds<ds)
            {
                ds = nds;
                ret = player;
            }
        }
        return ret;
    }

    static public GameObject FindClosetStar(GameObject go)
    {
        Vector3 pos = go.transform.position;
        GameObject ret = null;
        float ds = 0;
        if (playerList.Count == 0 && AiList.Count == 0)
        {
            return null;
        }
        else if(playerList.Count !=0)
        {
            ret = playerList[0];
            ds = Vector3.Distance(ret.transform.position, pos);
            foreach (GameObject player in playerList)
            {
                float nds = Vector3.Distance(player.transform.position, pos);
                if (nds < ds)
                {
                    ds = nds;
                    ret = player;
                }
            }
        }
        if (AiList.Count != 0)
        {
            if(ret == null)
            {
                ret = AiList[0];
                ds = Vector3.Distance(ret.transform.position, pos);
            }
            foreach (GameObject player in AiList)
            {
                float nds = Vector3.Distance(player.transform.position, pos);
                if (nds < ds && player != go)
                {
                    ds = nds;
                    ret = player;
                }
            }
        }
        return ret;
    }
}
