namespace DAL.Interfaces.DTO
{
    using System;

    public class DalComment: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PostId { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
