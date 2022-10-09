using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CommissionPreparer;

public class CommissionPreparerMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "commissionPreparerMenu";
    public IScreen? HostScreen { get; }
    
    private ICommand OnClickBtnCommissionControl { get; set; }
    private ICommand OnClickBtnCommissionMemberControl { get; set; }
    private ICommand OnClickBtnInspectedUnitControl { get; set; }
    private ICommand OnClickBtnInventoryControl { get; set; }

    public CommissionPreparerMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnCommissionControl = ReactiveCommand.Create(container.OpnCommissionControlPage);
        OnClickBtnCommissionMemberControl = ReactiveCommand.Create(container.OpnCommissionMemberControlPage);
        OnClickBtnInspectedUnitControl = ReactiveCommand.Create(container.OpnInspectedUnitControlPage);
        OnClickBtnInventoryControl = ReactiveCommand.Create(container.OpnInventoryControlPage);
    }
}