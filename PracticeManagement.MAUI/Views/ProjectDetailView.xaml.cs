using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;
namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]

[QueryProperty(nameof(ProjectId), "projectId")]
public partial class ProjectDetailView : ContentPage
{
    public int ClientId { get; set; }

    public int ProjectId { get; set; }
    public ProjectDetailView()
    {
        InitializeComponent();
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewModel(ClientId, ProjectId);
        (BindingContext as ProjectViewModel).RefreshProjects();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Clients");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    private void OpenClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button.BindingContext is BillViewModel bill)
        {
            Shell.Current.GoToAsync($"//BillDetailView?billId={bill.Model.Id}");
        }
    }

    private void AddBillClicked(object sender, EventArgs e)
    {
        var projectViewModel = BindingContext as ProjectViewModel;
        if (projectViewModel != null)
        {
            var newBill = new BillDTO
            {
                ProjectId = projectViewModel.Model.Id,
                ClientId = projectViewModel.Model.ClientId,
                
            };
            BillService.Current.AddOrUpdate(newBill);
            Shell.Current.GoToAsync($"//BillDetailView?billId={newBill.Id}");
        }
    }
}