using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPostComments.ViewModels
{
    public class PostViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime? CreatedOn { get; set; }
    }
}