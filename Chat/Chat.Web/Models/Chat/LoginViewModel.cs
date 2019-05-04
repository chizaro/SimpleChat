using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.Web.Models.Chat
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Это обязательное поле")]
        [Display(Name = "Введите имя")]
        public string Name { get; set; }
    }
}