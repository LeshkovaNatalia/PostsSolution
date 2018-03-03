namespace DAL.Interfaces.DTO
{
    using System;
    using System.Collections.Generic;

    public class DalPost : IEntity
    {
        public DalPost()
        {
            Comments = new List<DalComment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<DalComment> Comments { get; set; }
    }
}
