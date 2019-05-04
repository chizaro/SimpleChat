using Chat.Web.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Web.Controllers
{
    public class ChatController : Controller
    {
        private static ChatModel chat;

        public ChatController()
        {
            if (chat == null)
                chat = new ChatModel();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = new User()
            {
                Name = model.Name,
                LoginTime = DateTime.Now
            };
            Session["user"] = user;
            chat.Users.Add(user);

            chat.Messages.Add(new Message()
            {
                Text = user.Name + " вошел в чат",
                PublishDate = DateTime.Now,
                User = user
            });
            return RedirectToAction("Chat");
        }

        [HttpGet]
        public ActionResult Chat()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login");

            return View(chat);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            var user = (User)Session["user"];
            chat.Users.Remove(user);
            Session.Clear();

            chat.Messages.Add(new Message()
            {
                Text = user.Name + " покинул чат",
                PublishDate = DateTime.Now,
                User = user
            });
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult RenderMessage(MessageViewModel message)
        {
            chat.Messages.Add(new Message()
            {
                Text = message.Text,
                PublishDate = DateTime.Now,
                User = (User)Session["user"]
            });
            return PartialView("ChatInfo", chat);
        }

        [HttpGet]
        public ActionResult Refresh()
        {
            return PartialView("ChatInfo", chat);
        }
    }
}