using Microsoft.Maui.Dispatching;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        public ProjectDTO Project { get; set; }
        public BillDTO Bill { get; set; }

        public TimeSpan TimeX { get; private set; }

        public List<ProjectDTO> Projects
        {
            get
            {
                return ProjectService.Current.Projects;
            }
        }
        public List<BillDTO> Bills  // and here
        {
            get
            {
                return BillService.Current.Bills;  // and here
            }
        }
        public string TimerDisplay
        {
            get
            {
                var time = stopwatch.Elapsed;
                var str = string.Format("{0:00}:{1:00}:{2:00}",
                time.Hours,
                time.Minutes,
                time.Seconds);
                return str;
            }
        }
        public string ProjectDisplay
        {
            get
            {
                return Project.ShortName;
            }
        }

        private Window parentWindow;

        private IDispatcherTimer timer { get; set; }
        private Stopwatch stopwatch { get; set; }

        public ICommand StartCommand { get; private set; }
        public ICommand StopCommand { get; private set; }

        public ICommand SubmitCommand { get; private set; }
        public void ExecuteStart()
        {
            stopwatch.Start();
            timer.Start();
        }

        public void ExecuteStop()
        {
            stopwatch.Stop();
            TimeX = stopwatch.Elapsed;
            Bill.TimeSpent += TimeX;  
            NotifyPropertyChanged(nameof(TimeX));
            NotifyPropertyChanged(nameof(Bill));  
            BillService.Current.AddOrUpdate(Bill); 
        }

        public void ExecuteSubmit()
        {
            BillService.Current.AddOrUpdate(Bill);
            NotifyPropertyChanged(nameof(Bill));
            Application.Current.CloseWindow(parentWindow);
        }

        private void SetupCommands()
        {
            StartCommand = new Command(ExecuteStart);
            StopCommand = new Command(ExecuteStop);
            SubmitCommand = new Command(ExecuteSubmit);
        }
        public TimerViewModel(int billId, Window parentWindow)
        {
            //Project = ProjectService.Current.Get(projectId) ?? new Project();
            Bill = BillService.Current.Get(billId) ?? new BillDTO();  

            stopwatch = new Stopwatch();
            timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.IsRepeating = true;

            timer.Tick += Timer_Tick;
            SetupCommands();
            this.parentWindow = parentWindow;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timer.IsRunning)
            {
                NotifyPropertyChanged(nameof(TimerDisplay));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}