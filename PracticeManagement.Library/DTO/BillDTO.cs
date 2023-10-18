using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.DTO
{
    public class BillDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectId { get; set; }
        public float Rate { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public double TotalAmount { get; set; }
        public string Name { get; set; }


        public BillDTO()
        {
            Id = 0;
            ClientId = 0;
            DueDate = DateTime.Now;
            ProjectId = 0;
            Name = string.Empty;
            Rate = 0;
            TimeSpent = TimeSpan.Zero;
            TotalAmount = 0;
        }

        public BillDTO(Bill b)
        {
            this.Id = b.Id;
            this.ClientId = b.ClientId;
            this.DueDate = b.DueDate;
            this.ProjectId = b.ProjectId;
            this.Rate = b.Rate;
            Name = b.Name;
            this.TimeSpent = b.TimeSpent;
            this.TotalAmount = b.TotalAmount;
        }

        public override string ToString()
        {
            return string.Format(" ID: {0,-3}  --  ClientID: {1,-3} -- Total Amount Due: {2, -7}  -  Due Date: {3:MM/dd/yyyy}  -  ProjectId: {4,-3}", Id, ClientId, TotalAmount, DueDate, ProjectId);
        }

    }
}
