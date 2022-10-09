using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionPreparer;

public class InventoryControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "inventoryControl";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public InventoryControlPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}    