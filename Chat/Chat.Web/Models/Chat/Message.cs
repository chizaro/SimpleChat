using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Web.Models.Chat
{
    public class Message
    {
        public User User { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
    }
}