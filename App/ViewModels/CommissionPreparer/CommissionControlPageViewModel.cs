using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionPreparer;

public class CommissionControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "commissionControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public CommissionControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}    