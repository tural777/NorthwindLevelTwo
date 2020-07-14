using Entities.Concrete;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> categories { get; set; }
        public int currentCategoryId { get; set; }
    }
}
