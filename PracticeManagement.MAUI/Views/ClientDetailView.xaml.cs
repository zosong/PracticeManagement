using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;
namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientDetailView : ContentPage
{
    public int ClientId { get; set; }
    public ClientDetailView()
    {
        InitializeComponent();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Clients");
    }

    private void BillClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//Bills?clientId={ClientId}");
    }

    private void OpenClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ProjectDetail");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }
    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).RefreshProjectList();
    }


    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel(ClientId);

        (BindingContext as ClientViewModel).RefreshProjects();
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        var viewModel = BindingContext as ClientViewModel;
        viewModel?.RefreshProjects();

    }


}