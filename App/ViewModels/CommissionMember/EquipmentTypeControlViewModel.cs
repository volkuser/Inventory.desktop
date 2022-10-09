using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionMember;

public class EquipmentTypeControlViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "equipmentType";
    public IScreen? HostScreen { get; }
    private ApplicationContext Db { get; set; }

    public EquipmentTypeControlViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}    