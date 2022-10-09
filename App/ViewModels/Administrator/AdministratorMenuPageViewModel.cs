using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels.Administrator;

public class AdministratorMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "administratorMenu";
    public IScreen? HostScreen { get; }
    
    private ICommand OnClickBtnEmployeeControl { get; set; }
    private ICommand OnClickBtnTrainingCenterControl { get; set; }

    public AdministratorMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnEmployeeControl = ReactiveCommand.Create(container.OpnEmployeeControlPage);
        OnClickBtnTrainingCenterControl = ReactiveCommand.Create(container.OpnTrainingCenterControlPage);
    }
}