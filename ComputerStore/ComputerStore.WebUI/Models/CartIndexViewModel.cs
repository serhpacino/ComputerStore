using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}