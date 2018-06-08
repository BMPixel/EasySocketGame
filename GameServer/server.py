# coding:utf-8

import socket
import Package_pb2
import LoginMsg_pb2
import RequireMsg_pb2
import google.protobuf

UDP_IP = "127.0.0.1"
UDP_PORT = 10023



sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.bind((UDP_IP, UDP_PORT))
print('---Start to receive data---')

while 1:
    data, addr = sock.recvfrom(1024)
    s = Package_pb2.Package()
    s.ParseFromString(data)
    print("---Receive {data} from {ip}:{port}".format(data=data, ip=addr[0], port=addr[1]))
    if s.type == 1:
        li = LoginMsg_pb2.LoginMsg()
        li.ParseFromString(s.data)
        print li.__str__()



# s = MoveMsg_pb2.Package()
# s.time = 12
# ac = s.actions.add()
# ac.id = 10
# ac.dx = 1.3
# ac = s.actions.add()
# ac.id = 10
# ac.dx = 1.3
# code = s.SerializeToString()
# p = MoveMsg_pb2.Package()
# p.ParseFromString(code)
# print p.__str__()


