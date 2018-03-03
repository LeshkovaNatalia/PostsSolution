namespace BLL.Interfacies.Entities
{
    using System;

    public class CommentEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int PostId { get; set; }
    }
}
