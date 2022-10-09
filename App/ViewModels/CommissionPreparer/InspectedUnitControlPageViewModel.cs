using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionPreparer;

public class InspectedUnitControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "inspectedUnitControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public InspectedUnitControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}    