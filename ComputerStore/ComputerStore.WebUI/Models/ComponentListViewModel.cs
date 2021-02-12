using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class ComponentListViewModel
    {
        public IEnumerable<ComputerComponent> ComputerComponents { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}