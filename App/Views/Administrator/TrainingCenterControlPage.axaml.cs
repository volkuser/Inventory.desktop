using App.ViewModels.Administrator;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Administrator;

[DoNotNotify]
public partial class TrainingCenterControlPage : ReactiveUserControl<TrainingCenterControlPageViewModel>
{
    public TrainingCenterControlPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}