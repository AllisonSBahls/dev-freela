using DevFreela.Core.Enuns;
using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class Project
    {

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdUser { get; private set; }
        public int IdFreelancer { get; private set; }
        public decimal TotalCoast { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? StartAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; set; }

        public Project(string title, string description, int idUser, int idFreelancer, decimal totalCoast)
        {
            Title = title;
            Description = description;
            IdUser = idUser;
            IdFreelancer = idFreelancer;
            TotalCoast = totalCoast;

            CreatedAt = DateTime.Now; 
            Status = ProjectStatusEnum.CREATED;
            Comments = new List<ProjectComment>();
        }


    }
}
