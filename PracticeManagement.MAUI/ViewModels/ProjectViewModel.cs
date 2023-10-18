using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.Views;
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
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public ProjectDTO Model { get; set; }

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
                    .Select(k => new ProjectViewModel(k)));
            }
        }

        public ObservableCollection<BillViewModel> Bills => (Model == null || Model.Id == 0) 
            ? new ObservableCollection<BillViewModel>() 
            : new ObservableCollection<BillViewModel>(BillService.Current.Bills.Where(b => b.ProjectId == Model.Id).Select(bl => new BillViewModel(bl)));
        

/*        public ICommand BillCommand { get; private set; }*/
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
/*        public ICommand TimerCommand { get; private set; }*/

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public void ExecuteDelete(int id)
        {
            ProjectService.Current.Delete(id);
        }

        private void ExecuteAdd()
        {
            ProjectService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
        }

        public void ExecuteEdit(int id)
        {
            ProjectService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.ClientId}&projectId={Model.Id}");
        }

/*        private void ExecuteTimer()
        {
            var window = new Window()
            {
                Width = 250,
                Height = 350,
                X = 0,
                Y = 0
            };
            var view = new TimerView(Model.Id, window);
            window.Page = view;
            Application.Current.OpenWindow(window);
        }*/

/*        private void ExecuteBill()
        {
            Shell.Current.GoToAsync($"//BillDetailView");
        }*/


        public void RefreshProjects()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public void SetupCommands()
        {
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ProjectViewModel).Model.Id));
            EditCommand = new Command(
                (c) => ExecuteEdit((c as ProjectViewModel).Model.Id));
            AddCommand = new Command(ExecuteAdd);
/*            TimerCommand = new Command(ExecuteTimer);
            BillCommand = new Command(ExecuteBill);*/
        }

        public void AddOrUpdate()
        {
            ProjectService.Current.AddOrUpdate(Model);
        }

        public ProjectViewModel()
        {
            Model = new ProjectDTO();
            SetupCommands();
        }
        public ProjectViewModel(int clientId, int projectId)
        {
            if (projectId == 0)
            {
                Model = new ProjectDTO { ClientId = clientId };
            }
            else
            {
                Model = ProjectService.Current.Get(projectId);
            }
            SetupCommands();
        }

        public ProjectViewModel(ProjectDTO model)
        {
            Model = model;
            SetupCommands();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
