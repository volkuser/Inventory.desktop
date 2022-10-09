using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.Administrator;

public class EmployeeControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "employeeControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public EmployeeControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}    