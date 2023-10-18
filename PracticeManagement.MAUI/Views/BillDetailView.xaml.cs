using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]

[QueryProperty(nameof(BillId), "billId")]
[QueryProperty(nameof(ProjectId), "projectId")]
public partial class BillDetailView : ContentPage
{
    public int ProjectId { get; set; }
    public int ClientId { get; set; }
    public int BillId { get; set; }
    public BillDetailView()
    {
		InitializeComponent();
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new BillViewModel(ClientId,BillId, ProjectId);
        (BindingContext as BillViewModel).RefreshBills();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as BillViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Clients");
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        (BindingContext as BillViewModel).RefreshBills();
    }
}
