using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Proyetct11.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product{ get; set; }

        [ValidateNever]

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
