using PracticeManagement.Library.DTO;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PracticeManagement.Library.Models
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string? ShortName { get; set; }
        public string? LongName { get; set; }
        public int ClientId { get; set; }

        public List<Bill>? Bills { get; set; }




        public override string ToString()
        {
            return string.Format(" Id: {0,-3}\tLongName: {1,-20}\tShortName: {2,-4}\tOpenDate: {3,-10:MM/dd/yyyy}\tClosedDate: {4,-10:MM/dd/yyyy}\tIsActive: {5,-5}\tClientId: {6,-2}", Id, LongName, ShortName, OpenDate, ClosedDate, IsActive, ClientId);
        }


        public Project()
        {
            Id = 0 ;
            OpenDate = DateTime.Now;
            ClosedDate = DateTime.Now.AddYears(1);
            LongName = string.Empty;
            ShortName = string.Empty;
            IsActive = false;
            Bills = new List<Bill>();
            ClientId = 0;
        }


        public Project(ProjectDTO dto)
        {
            this.Id = dto.Id;
            this.OpenDate = dto.OpenDate;
            this.ClosedDate = dto.ClosedDate;
            this.IsActive = dto.IsActive;
            this.LongName = dto.LongName;
            this.ShortName = dto.ShortName;
            this.ClientId = dto.ClientId;
            this.Bills = dto.Bills;
        }
    }
}
