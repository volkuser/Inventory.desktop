using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionMember;

public class CommissionMemberMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "commissionMemberMenu";
    public IScreen HostScreen { get; }

    public CommissionMemberMenuPageViewModel(User currentUser, IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}