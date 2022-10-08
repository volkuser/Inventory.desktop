using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionPreparer;

public class CommissionPreparerMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "commissionPreparerMenu";
    public IScreen HostScreen { get; }

    public CommissionPreparerMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}