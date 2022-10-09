using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionMember;

public class AudienceControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "audienceControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public AudienceControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}    