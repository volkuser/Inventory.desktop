using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionPreparer;

public class CommissionMemberControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "commissionMemberControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public CommissionMemberControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}