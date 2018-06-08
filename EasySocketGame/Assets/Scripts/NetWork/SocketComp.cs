using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ProtoBuf;
using System.IO;

public class SocketComp : MonoBehaviour
{
    public Socket sock;

    // Use this for initialization
    void Start()
    {
        Package.Package package = Make();
        MemoryStream ms = new MemoryStream();
        ProtoBuf.Serializer.Serialize<Package.Package>(ms, package);
        byte[] arr = ms.ToArray();
        EndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"),10023);
        sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        sock.SendTo(arr, point);
        Debug.Log("Send successfully");
        

    }

    Package.Package Make()
    {
        Package.Package p = new Package.Package();
        p.type = Package.Package.Type.login;
        LoginMsg.LoginMsg ball = new LoginMsg.LoginMsg();
        ball.id = 3;
        ball.name = "xxh";
        ball.x = 20.5f;
        ball.y = 10.44f;
        ball.size = 20;
        byte[] arr = null;
        using(MemoryStream ms = new MemoryStream())
        {
            ProtoBuf.Serializer.Serialize<LoginMsg.LoginMsg>(ms,ball);
            arr = ms.ToArray();
        }
        p.data = arr;
        return p;
    }

    // Update is called once per frame
    void Update()
    {

    }
}