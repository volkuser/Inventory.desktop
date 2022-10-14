using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionMember;

public class CommissionMemberMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "commissionMemberMenu";
    public IScreen? HostScreen { get; }
    private ICommand OnClickBtnEquipmentControl { get; set; }
    private ICommand OnClickBtnEquipmentTypeControl { get; set; }
    private ICommand OnClickBtnEquipmentUnitControl { get; set; }

    public CommissionMemberMenuPageViewModel(User currentUser, IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnEquipmentControl = ReactiveCommand.Create(container.OpnEquipmentControlPage);
        OnClickBtnEquipmentTypeControl = ReactiveCommand.Create(container.OpnEquipmentTypeControlPage);
        OnClickBtnEquipmentUnitControl = ReactiveCommand.Create(() 
            => container.OpnEquipmentUnitControlPage(currentUser));
    }
}