using App.Models;

namespace App.ViewModels;

public interface IPageNavigation
{
    public void OpnAuthorizationPage();
    
    public void OpnAdministratorMenuPage();
    public void OpnEmployeeControlPage();
    public void OpnTrainingCenterControlPage();
    
    public void OpnCommissionMemberMenuPage(User currentUser);
    public void OpnEquipmentControlPage();
    public void OpnEquipmentTypeControlPage();
    public void OpnEquipmentUnitControlPage(User currentUser);

    public void OpnCommissionPreparerMenuPage();
    public void OpnCommissionControlPage();
    public void OpnCommissionMemberControlPage();
    public void OpnInspectedUnitControlPage();
    public void OpnInventoryControlPage();

    public void Back();
}