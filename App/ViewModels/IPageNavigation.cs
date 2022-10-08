using App.Models;

namespace App.ViewModels;

public interface IPageNavigation
{
    public void OpnAuthorizationPage();
    public void OpnAdministratorMenuPage();
    public void OpnCommissionMemberMenuPage(User currentUser);
    public void OpnCommissionPreparerMenuPage();

    public void Back();
}