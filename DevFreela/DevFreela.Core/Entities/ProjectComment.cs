using System;

namespace DevFreela.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int idUser { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}