using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.Library.DTO
{

    public class ClientDTO 
    { 
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public List<Project>? Projects { get; set; }

        public List<Bill>? Bills { get; set; }


        public ClientDTO()
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
        
        public ClientDTO(Client c)
        {
            this.Id = c.Id;
            this.OpenDate = c.OpenDate;
            this.ClosedDate = c.ClosedDate;    
            this.IsActive = c.IsActive;
            Name = c.Name;
            Notes = c.Notes;
            Projects = new List<Project>();
            Bills = new List<Bill>();

        }

        public override string ToString()
        {
            return string.Format(" Id: {0,-3}\tName: {1,-20}\tOpenDate: {2,-10:MM/dd/yyyy}\tClosedDate: {3,-10:MM/dd/yyyy}\tIsActive: {4,-5}\tNotes: {5,-30}", Id, Name, OpenDate, ClosedDate, IsActive, Notes);
        }

    }
}