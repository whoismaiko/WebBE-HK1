using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace BE2.Models.ViewModel
{
    public class ProductSearchVM
    {
        public string SearchTerm { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;

        public string sortOrder { get; set; }
        
        
        public PagedList.IPagedList<BE2.Product> Products { get; set; }
    }
}