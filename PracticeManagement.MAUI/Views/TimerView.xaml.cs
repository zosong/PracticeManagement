using PracticeManagement.MAUI.ViewModels;
namespace PracticeManagement.MAUI.Views;

public partial class TimerView : ContentPage
{
    /*    public TimerView(int projectId, Window parentWindow)
        {
            InitializeComponent();
            BindingContext = new TimerViewModel(projectId, parentWindow);
        }*/
    public TimerView(int billId, Window parentWindow) 
    {
        InitializeComponent();
        BindingContext = new TimerViewModel(billId, parentWindow); 
    }
}