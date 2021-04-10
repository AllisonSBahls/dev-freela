using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.ViewModel
{
    public class ProjectViewModel
    {
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ProjectViewModel(string title, DateTime createdAt)
        {
            Title = title;
            CreatedAt = createdAt;
        }
    }
}
