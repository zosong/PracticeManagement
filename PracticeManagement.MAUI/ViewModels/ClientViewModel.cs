using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public ClientDTO Model { get; set; }

        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<ProjectViewModel>();
                }
                return new ObservableCollection<ProjectViewModel>(ProjectService
                    .Current.Projects.Where(p => p.ClientId == Model.Id)
                    .Select(r => new ProjectViewModel(r)));
            }
        }


        public ObservableCollection<BillViewModel> Bills
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<BillViewModel>();
                }
                return new ObservableCollection<BillViewModel>(BillService
                    .Current.Bills.Where(b => b.ClientId == Model.Id)
                    .Select(r => new BillViewModel(r)));
            }
        }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddProjectCommand { get; private set; }
        public ICommand AddNewProjectCommand { get; private set; }
        public ICommand ShowBillsCommand { get; private set; }
        public ICommand ShowProjectsCommand { get; private set; }
        public ICommand AddCommand { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }

        public void ExecuteShowProjects(int id)
        {
            
            Shell.Current.GoToAsync($"//Projects?clientId={id}");
        }

        public void ExecuteShowBills(int id)
        {

            Shell.Current.GoToAsync($"//Bills?clientId={id}");
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");
        }

        public void ExecuteAdd(int id)
        {
            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");
        }




        public void RefreshProjects()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public void ExecuteAddProject()
        {
            AddOrUpdate(); // 7/11/23
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.Id}");

        }

        public void ExecuteAddNewProject()
        {
            AddNewProject(); // 7/11/23
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.Id}");
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command(
                (c) => ExecuteEdit((c as ClientViewModel).Model.Id));
            AddProjectCommand = new Command(
                (c) => ExecuteAddProject());
            AddNewProjectCommand = new Command(
                (c) => ExecuteAddNewProject());
            ShowProjectsCommand = new Command(
                (c) => ExecuteShowProjects((c as ClientViewModel).Model.Id));
            ShowBillsCommand = new Command(
                (c) => ExecuteShowBills((c as ClientViewModel).Model.Id));
            AddCommand = new Command(
                (c) => ExecuteAdd((c as ClientViewModel).Model.Id));


        }

        public ClientViewModel(ClientDTO client)
        {
            Model = client;
            SetupCommands();
        }

        public ClientViewModel(int clientId)
        {
            if(clientId > 0)
            {
                Model = ClientService.Current.Get(clientId);
            }
            else
            {
                Model = new ClientDTO();
            }
            SetupCommands();
        }

        public ClientViewModel()
        {
            Model = new ClientDTO();
            SetupCommands();
        }

        public void AddOrUpdate()
        {
            ClientService.Current.AddOrUpdate(Model);
        }
        private void AddClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ProjectDetail");
        }

        public void AddNewProject()
        {
            ClientService.Current.AddOrUpdate(Model);
        }

    }
}