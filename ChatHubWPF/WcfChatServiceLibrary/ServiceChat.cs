using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfChatServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;

        public int Connect(string name)
        {
            ServerUser user = new ServerUser() { ID = nextId++, Name = name, operationContext = OperationContext.Current };
            SendMsg("\t" + user.Name + " is connected!", user.ID);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            foreach (var item in users)
            {
                if (item.ID == id) users.Remove(item);
                SendMsg("\t" + item.Name + " is disconnected!", 0);
            }
        }

        public void SendMsg(string msg, int id)
        {
            string answer="";
            foreach (var Item in users)
            {
                answer = DateTime.Now.ToShortTimeString();
                foreach (var item in users)
                {
                    if (id == item.ID)
                    {
                        answer += "\t" + item.Name + ": ";
                    }
                }
                answer += msg;
                Item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }
        }
    }
}
