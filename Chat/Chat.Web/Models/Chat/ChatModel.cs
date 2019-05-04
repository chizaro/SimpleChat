using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Web.Models.Chat
{
    public class ChatModel
    {
        public List<User> Users { get; set; }

        public List<Message> Messages { get; set; }

        public ChatModel()
        {
            Users = new List<User>();
            Messages = new List<Message>();
        }
    }
}