using PracticeManagement.Library.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Models
{
    public class Bill : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectId { get; set; }
        
        private float rate;

        private TimeSpan timeSpent;

        public float Rate
        {
            get { return rate; }
            set
            {
                if (rate != value)
                {
                    rate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalAmount));
                }
            }
        }
        
        public TimeSpan TimeSpent
        {
            get { return timeSpent; }
            set
            {
                if (timeSpent != value)
                {
                    timeSpent = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalAmount));
                }
            }
        }
        public double TotalAmount
        {
            get
            {
                return Rate * TimeSpent.TotalHours;
            }
        }

        public override string ToString()
        {
            return string.Format(" ID: {0,-3}  --  ClientID: {1,-3} -- Total Amount Due: {2, -7}  -  Due Date: {3:MM/dd/yyyy}  -  ProjectId: {4,-3}", Id, ClientId, TotalAmount, DueDate, ProjectId);
        }
        public Bill()
        {
            Id = 0;
            ClientId = 0;
            ProjectId = 0;
            Rate = 0;
            Name = string.Empty;
            TimeSpent = TimeSpan.Zero;
            DueDate = new DateTime();

        }

        public Bill(BillDTO dto)
        {
            this.Id = dto.Id;
            this.ClientId = dto.ClientId;
            this.ProjectId = dto.ProjectId;
            this.Rate = dto.Rate;
            Name = string.Empty;
            this.TimeSpent = dto.TimeSpent;
            this.DueDate = dto.DueDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

    
}
