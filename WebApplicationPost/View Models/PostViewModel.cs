namespace WebApplicationPost.View_Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class PostViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required, DataType(DataType.Text), StringLength(100)]
        public string Name { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? CreatedOn { get; set; }
    }
}