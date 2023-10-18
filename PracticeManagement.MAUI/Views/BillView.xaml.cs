using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;
namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ProjectId), "projectId")]

[QueryProperty(nameof(ClientId), "clientId")]
public partial class BillView : ContentPage
{
    public int ClientId { get; set; }
    public int ProjectId { get; set; }
    public BillView()
    {
        InitializeComponent();
        BindingContext = new BillViewViewModel(ClientId);
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as BillViewViewModel).RefreshProjectList();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var bill = (sender as Button).CommandParameter as BillViewModel;
        if (bill != null)
        {
            var id = bill.Model.Id;
            Shell.Current.GoToAsync($"//BillDetailView?billId={id}&clientId={ClientId}&projectId={ProjectId}");
        }
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new BillViewViewModel(ClientId);
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

}