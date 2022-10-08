using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views;

[DoNotNotify]
public partial class AuthorizationPage : ReactiveUserControl<AuthorizationPageViewModel>
{
    public AuthorizationPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}