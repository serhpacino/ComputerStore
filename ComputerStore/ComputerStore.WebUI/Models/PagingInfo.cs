using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerStore.WebUI.Models
{
    public class PagingInfo
    {
        //total items
        public int TotalItems { get; set; }

        //quantity of items per page
        public int ItemsPerPage { get; set; }

        //number of current page
        public int CurrentPage { get; set; }

        //total pages
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}