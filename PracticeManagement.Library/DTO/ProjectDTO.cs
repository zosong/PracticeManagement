using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.DTO
{
    public class ProjectDTO
    {

        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string? LongName { get; set; }
        public string? ShortName { get; set; }
        public int ClientId { get; set; }

        public List<Bill>? Bills { get; set; }


        public ProjectDTO()
        {
            Id = 0;
            OpenDate = DateTime.Now;
            ClosedDate = DateTime.Now.AddYears(1);
            IsActive = false;
            LongName = string.Empty;
            ShortName = string.Empty;
            ClientId = 0;
            Bills = new List<Bill>();

        }

        public ProjectDTO(Project p)
        {
            this.Id = p.Id;
            this.OpenDate = p.OpenDate;
            this.ClosedDate = p.ClosedDate;
            this.IsActive = p.IsActive;
            LongName = p.LongName;
            ShortName = p.ShortName;
            this.ClientId = p.ClientId;
            Bills = new List<Bill>();

        }

        public override string ToString()
        {
            return string.Format(" Id: {0,-3}\tLongName: {1,-20}\tShortName: {2,-4}\tOpenDate: {3,-10:MM/dd/yyyy}\tClosedDate: {4,-10:MM/dd/yyyy}\tIsActive: {5,-5}\tClientId: {6,-2}", Id, LongName, ShortName, OpenDate, ClosedDate, IsActive, ClientId);
        }

    }
}
