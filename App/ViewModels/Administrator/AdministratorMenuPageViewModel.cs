using ReactiveUI;
using Splat;

namespace App.ViewModels.Administrator;

public class AdministratorMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "administratorMenu";
    public IScreen HostScreen { get; }

    public AdministratorMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}