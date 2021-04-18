using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.ViewModel
{
    public class ProjectDetailsViewModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCoast { get; private set; }
        public DateTime? StartedAt   { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public DateTime? CreatedAt { get; private set; }

        public string ClientFullName { get; private set; }
        public string FreelancerFullName { get; private set; }
        public ProjectDetailsViewModel(int id, string title, string description, decimal totalCoast, DateTime? startedAt, DateTime? finishedAt, DateTime? createdAt, string clientFullName, string freelancerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCoast = totalCoast;
            CreatedAt = createdAt;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClientFullName = clientFullName;
            FreelancerFullName = freelancerFullName;
        }
    }
}
