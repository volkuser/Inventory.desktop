using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using App.ViewModels;
using App.Views;
using PropertyChanged;
using ReactiveUI;
using Splat;

namespace App;

[DoNotNotify]
public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Locator.CurrentMutable.RegisterConstant<IScreen>(new MainWindowViewModel());
        // Locator.CurrentMutable.Register<IViewFor<MainMenuPageViewModel>>(() => new MainMenuPage());

        new MainWindow { DataContext = Locator.Current.GetService<IScreen>() }.Show();
        
        base.OnFrameworkInitializationCompleted();
    }
}