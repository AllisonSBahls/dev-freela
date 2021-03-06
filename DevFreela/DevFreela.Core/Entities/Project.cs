using DevFreela.Core.Enuns;
using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; set; }
        public decimal TotalCoast { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; set; }

        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCoast)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCoast = totalCoast;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.CREATED;
            Comments = new List<ProjectComment>();
        }

        public void Cancel()
        {
            if(Status == ProjectStatusEnum.INPROGRESS) { 
                Status = ProjectStatusEnum.CANCELLED;
            }
        }

        public void Finished()
        {
            if (Status == ProjectStatusEnum.PAYMENTPENDING)
            {
                Status = ProjectStatusEnum.FINISHED;
                FinishedAt = DateTime.Now;
            }
        }

        public void SetPaymentPending()
        {
            Status = ProjectStatusEnum.PAYMENTPENDING;
            FinishedAt = null;
        }

        public void Started()
        {
            if (Status == ProjectStatusEnum.CREATED)
            {
                Status = ProjectStatusEnum.INPROGRESS;
                StartedAt = DateTime.Now;

            }
        }

        public void Update(string title, string description, decimal totalCoast)
        {
            Title = title;
            Description = description;
            TotalCoast = totalCoast;
        }

    }
}
