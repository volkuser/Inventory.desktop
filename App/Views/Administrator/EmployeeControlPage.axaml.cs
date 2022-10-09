using App.ViewModels.Administrator;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Administrator;

[DoNotNotify]
public partial class EmployeeControlPage : ReactiveUserControl<EmployeeControlPageViewModel>
{
    public EmployeeControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}