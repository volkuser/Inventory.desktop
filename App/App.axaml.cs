using Avalonia;
using Avalonia.Markup.Xaml;
using App.ViewModels;
using App.ViewModels.Administrator;
using App.ViewModels.CommissionMember;
using App.ViewModels.CommissionPreparer;
using App.Views;
using App.Views.Administrator;
using App.Views.CommissionMember;
using App.Views.CommissionPreparer;
using PropertyChanged;
using ReactiveUI;
using Splat;

namespace App;

[DoNotNotify]
public class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        Locator.CurrentMutable.RegisterConstant<IScreen>(new MainWindowViewModel());
        Locator.CurrentMutable.Register<IViewFor<AuthorizationPageViewModel>>(() => new AuthorizationPage());
        Locator.CurrentMutable.Register<IViewFor<AdministratorMenuPageViewModel>>(() 
            => new AdministratorMenuPage());
        Locator.CurrentMutable.Register<IViewFor<CommissionMemberMenuPageViewModel>>(() 
            => new CommissionMemberMenuPage());
        Locator.CurrentMutable.Register<IViewFor<CommissionPreparerMenuPageViewModel>>(() 
            => new CommissionPreparerMenuPage());
        

        new MainWindow { DataContext = Locator.Current.GetService<IScreen>() }.Show();
        
        base.OnFrameworkInitializationCompleted();
    }
}