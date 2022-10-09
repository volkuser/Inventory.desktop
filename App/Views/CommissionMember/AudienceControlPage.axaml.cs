using App.ViewModels.CommissionMember;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.CommissionMember;

[DoNotNotify]
public partial class AudienceControlPage : ReactiveUserControl<AudienceControlPageViewModel>
{
    public AudienceControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}