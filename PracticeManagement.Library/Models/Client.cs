using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;

namespace PracticeManagement.Library.Models
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        
        public List<Project>? Projects { get; set; }

        public List<Bill>? Bills { get; set; }


        public Client()
        {
            Id = 0;
            OpenDate = DateTime.Now;
            ClosedDate = DateTime.Now.AddYears(1);
            IsActive = false;
            Name = string.Empty;
            Notes = string.Empty;

            Projects = new List<Project>();

            Bills = new List<Bill>();

        }
        public Client(ClientDTO dto)
        {
            this.Id = dto.Id;
            this.OpenDate = dto.OpenDate;
            this.ClosedDate = dto.ClosedDate;   
            this.IsActive = dto.IsActive;
            this.Name = dto.Name;
            this.Notes = dto.Notes;
            this.Projects = dto.Projects;
            this.Bills = dto.Bills;
        }
        public override string ToString()
        {
            return string.Format(" Id: {0,-3}\tName: {1,-20}\tOpenDate: {2,-10:MM/dd/yyyy}\tClosedDate: {3,-10:MM/dd/yyyy}\tIsActive: {4,-5}\tNotes: {5,-30}", Id, Name, OpenDate, ClosedDate, IsActive, Notes);
        }

    }
}
