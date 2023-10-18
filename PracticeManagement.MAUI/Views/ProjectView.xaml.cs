using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectView : ContentPage
{
    public int ClientId { get; set; }
    public ProjectView()
    {
        InitializeComponent();
        BindingContext = new ProjectViewViewModel(ClientId);
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).RefreshProjectList();
    }

    private void EditClicked(object sender, EventArgs e)
    {

        (BindingContext as ProjectViewViewModel).RefreshProjectList();
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewViewModel(ClientId);

    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }
}
