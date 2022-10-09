using App.ViewModels.CommissionPreparer;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.CommissionPreparer;

[DoNotNotify]
public partial class InventoryControlPage : ReactiveUserControl<InventoryControlPageViewModel>
{
    public InventoryControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}