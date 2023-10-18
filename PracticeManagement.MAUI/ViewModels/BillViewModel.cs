using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
    public class BillViewModel : INotifyPropertyChanged
    {

        public BillDTO Model { get; set; }

        public ObservableCollection<BillViewModel> Bills
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<BillViewModel>();
                }
                return new ObservableCollection<BillViewModel>(BillService
                    .Current.Bills.Where(p => p.ClientId == Model.Id)
                    .Select(b => new BillViewModel(b)));

            }
        }



        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand TimerCommand { get; private set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public void ExecuteDelete(int id)
        {
            BillService.Current.Delete(id);
        }
        public void ExecuteEdit(int id)
        {
            BillService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//BillDetail?clientId={Model.ClientId}&billId={Model.Id}&projectId={Model.ProjectId}");

        }

        private void ExecuteAdd()
        {
            BillService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
        }

        public void SetupCommands()
        {
            EditCommand = new Command(
                (c) => ExecuteEdit((c as BillViewModel).Model.Id));
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as BillViewModel).Model.Id));
            AddCommand = new Command(ExecuteAdd);
            TimerCommand = new Command(ExecuteTimer);
        }

        public void AddOrUpdate()
        {
            BillService.Current.AddOrUpdate(Model);
        }

        public BillViewModel()
        {
            Model = new BillDTO();
            SetupCommands();
        }

        public BillViewModel(int clientId, int billId, int projectId)
        {
            if (billId == 0)
            {
                Model = new BillDTO { ClientId = clientId, ProjectId = projectId };
            }
            else
            {
                Model = BillService.Current.Get(billId);
            }
            SetupCommands();
        }



        public BillViewModel(BillDTO model)
        {
            Model = model;
            SetupCommands();
        }


        public void ExecuteTimer()
        {
            var window = new Window()
            {
                Width = 250,
                Height = 350,
                X = 0,
                Y = 0
            };
            var view = new TimerView(Model.Id, window); // Ensure that TimerView and TimerViewModel are set up for Bills
            window.Page = view;
            Application.Current.OpenWindow(window);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshBills()
        {
            NotifyPropertyChanged(nameof(Bills));
        }
    }
}
