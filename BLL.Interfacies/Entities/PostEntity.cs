namespace BLL.Interfacies.Entities
{
    using System;

    public class PostEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Name { get; set; }
    }
}
