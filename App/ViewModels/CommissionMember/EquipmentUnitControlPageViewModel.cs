using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionMember;

public class EquipmentUnitControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "equipmentUnit";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public EquipmentUnitControlPageViewModel(User currentUser, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}    