using App.ViewModels.CommissionMember;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.CommissionMember;

[DoNotNotify]
public partial class EquipmentTypeControlPage : ReactiveUserControl<EquipmentTypeControlViewModel>
{
    public EquipmentTypeControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}