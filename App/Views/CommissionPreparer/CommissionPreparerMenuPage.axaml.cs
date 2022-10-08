using App.ViewModels.CommissionPreparer;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.CommissionPreparer;

[DoNotNotify]
public partial class CommissionPreparerMenuPage : ReactiveUserControl<CommissionPreparerMenuPageViewModel>
{
    public CommissionPreparerMenuPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}