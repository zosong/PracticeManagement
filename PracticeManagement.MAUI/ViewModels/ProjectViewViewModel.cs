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
    public class ProjectViewViewModel : INotifyPropertyChanged
    {
        public ClientDTO Client { get; set; }
        public ProjectDTO SelectedProject { get; set; }

        public ICommand SearchCommand { get; private set; }

        public string Query { get; set; }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                return
                    new ObservableCollection<ProjectViewModel>
                    (ProjectService
                        .Current.Search(Query ?? string.Empty)
                        .Select(c => new ProjectViewModel(c)).ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ProjectViewViewModel(int clientId)
        {
            if (clientId > 0)
            {
                Client = ClientService.Current.Get(clientId);
            }
            else
            {
                Client = new ClientDTO();
            }

        }

        public void Delete()
        {
            if (SelectedProject != null)
            {
                ProjectService.Current.Delete(SelectedProject.Id);
                SelectedProject = null;
                NotifyPropertyChanged(nameof(Projects));
                NotifyPropertyChanged(nameof(SelectedProject));
            }
        }

        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(Projects));
        }
    }
}