using RestfulApi.Business.Services.Abstract;
using RestfulApi.Models;
using System;
using System.Collections.Generic;
using RestfulApi.Business.Extensions;


namespace RestfulApi.Business.Services.Concrete
{
    public class MissionService : IMissionService
    {

        private List<Mission> _missions;

        public MissionService() {

            _missions = new List<Mission>()
            {
                new Mission { Id = 1, Title = "Pay bills", Description = "Pay electricity, water, and internet bills", Deadline = DateTime.Now.AddDays(5), IsCompleted = false, Priority = 4, Tags = new List<string> { "finance", "bills" } },
                new Mission { Id = 2, Title = "Write API documentation", Description = "Write detailed documentation for the RESTful API endpoints", Deadline = DateTime.Now.AddDays(2), IsCompleted = true, Priority = 2, Tags = new List<string> { "documentation", "API", "business" } },
                new Mission { Id = 3, Title = "Buy groceries", Description = "Buy vegan milk, cucumber and cat food.", Deadline = DateTime.Now.AddDays(1), IsCompleted = false, Priority = 1, Tags = new List<string> { "groceries", "home" } },
                new Mission { Id = 4, Title = "Clean the house", Description = "Vacuum, dust and mop.", Deadline = DateTime.Now.AddDays(4), IsCompleted = false, Priority = 4, Tags = new List<string> { "cleaning", "home" } },
                new Mission { Id = 5, Title= "Take the cat to the vet", Description= "Take the cat to the vet and tell her about her recent condition and ask her to check her kidneys.", Deadline = DateTime.Now.AddDays(2), IsCompleted = true, Priority = 5, Tags = new List<string> { "vet","health","home","family"} },
                new Mission { Id = 6, Title = "Call mom", Description = "Call mom to catch up and see how she's doing.", Deadline = DateTime.Now.AddDays(1), IsCompleted = true, Priority = 1, Tags = new List<string> { "family", "communication" } },
                new Mission { Id = 7, Title = "Have a meeting with the advisor", Description = "Have a meeting with the advisor and ask her what you need to do and the documents you need to submit in order for your graduation to be finalized.", Deadline = DateTime.Now.AddDays(8), IsCompleted = false, Priority = 5, Tags = new List<string> { "graduation", "education" } },
                new Mission { Id = 8, Title = "Volunteer at shelter", Description = "Help out at a local animal shelter for a few hours.", Deadline = DateTime.Now.AddDays(3), IsCompleted = true, Priority = 2, Tags = new List<string> { "volunteering", "animals" } },
                new Mission { Id = 9, Title = "Add unit tests", Description = "Write comprehensive unit tests for the core functionality", Deadline = DateTime.Now.AddDays(4), IsCompleted = false, Priority = 3, Tags = new List<string> { "testing", "unit tests", "business" } },
                new Mission { Id = 10, Title = "Create monthly budget", Description = "Review income and expenses to create a detailed monthly budget for better financial planning.", Deadline = DateTime.Now.AddDays(6), IsCompleted = false, Priority = 2, Tags = new List<string> { "finance", "budgeting" } }
            };

        }

     
        public string CustomDateFormat(Mission mission)
        {
            return mission.ToCustomDateFormat();
        }

        public List<Mission> GetAllMissions()
        {
            return _missions;
        }
    }
}
