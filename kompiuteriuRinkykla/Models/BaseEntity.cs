using System;

namespace kompiuteriuRinkykla.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public BaseEntity()
        {
            DateCreated = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;
        }
    }
}
