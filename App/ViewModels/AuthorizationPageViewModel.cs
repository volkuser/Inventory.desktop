using System.Linq;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class AuthorizationPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "authorization";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private string? Login { get; set; } 
    private string? Password { get; set; } 
    
    private ICommand OnClickBtnLogin { get; set; }

    public AuthorizationPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        OnClickBtnLogin = ReactiveCommand.Create(() => AttemptedAuthorization(container));
    }

    private void AttemptedAuthorization(IPageNavigation container)
    {
        var user = new User();
        if (Db.Users != null) user = Db.Users.FirstOrDefault(x => x.Login!.Equals(Login));
        if (user == null) return;
        if (user.Password!.Equals(Password))
        {
            switch (user.RoleId)
            {
                case 1:  // administrator
                    container.OpnAdministratorMenuPage();
                    break;
                case 2: // commission preparer
                    container.OpnCommissionPreparerMenuPage();
                    break;
                case 3: // commission member
                    container.OpnCommissionMemberMenuPage(user);
                    break;
            }
        }
        else
        {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Ошибка входа", "Неверный пароль.");
            messageBox.Show();
        }
    }
}