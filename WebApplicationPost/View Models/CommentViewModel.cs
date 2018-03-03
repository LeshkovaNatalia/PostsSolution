namespace WebApplicationPost.View_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CommentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required, DataType(DataType.Text), StringLength(100)]
        public string Name { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? CreatedOn { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int PostId { get; set; }
    }
}