using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels {

    public class BillViewViewModel : INotifyPropertyChanged
    {

        public Project Project { get; set; }

        public ClientDTO Client { get; set; }

        public BillDTO SelectedBill { get; set; }
        public ICommand SearchCommand { get; private set; }
        public int Query { get; set; }
        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Bills));
        }

        public ObservableCollection<BillViewModel> Bills
        {
            get
            {

                return new ObservableCollection<BillViewModel>(
                    BillService.Current.Search(Client?.Id??0)
                        .Select(x => new BillViewModel(x))
                        .ToList());
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BillViewViewModel(int clientId)
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
            if (SelectedBill != null)
            {
                BillService.Current.Delete(SelectedBill.Id);
                SelectedBill = null;
                NotifyPropertyChanged(nameof(Bills));
                NotifyPropertyChanged(nameof(SelectedBill));
            }
        }

        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(Bills));
        }


    }
}